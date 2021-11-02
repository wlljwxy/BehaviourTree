using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 选择节点
    /// </summary>
    public class SelectNode:NodeComposite
    {
        private NodeBase lastRunningNode;
        public static string descript = "选择节点一次遍历所有子节点，如果都返回Fail" +
            "则向父节点返回Fail   直到有一个节点返回Success或者Running,停止后续" +
            "节点的执行，向父节点返回Success或Running   注意如果返回Running" +
            "需要记住这个节点，下次直接从此节点开始执行";

        public SelectNode() : base(NODE_TYPE.SELECT)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
            if (null != lastRunningNode)
            {
                lastRunningNode.PostPosition(ResultType.Fail);
                lastRunningNode = null;
            }
        }

        public override ResultType Execute()
        {
            int index = 0;
            if (lastRunningNode != null)
            {
                index = lastRunningNode.NodeIndex;
            }
            lastRunningNode = null;

            ResultType resultType = ResultType.Fail;
            for (int i = index ; i < nodeChildList.Count; ++i)
            {
                NodeBase nodebase = nodeChildList[i];

                nodebase.Preposition();
                resultType = nodebase.Execute();
                nodebase.PostPosition(resultType);

                if (resultType == ResultType.Fail)
                {
                    continue;
                }
                else if(resultType == ResultType.Success)
                {
                    break;
                }else if (resultType == ResultType.Running)
                {
                    lastRunningNode = nodebase;
                    break;
                }
            }

            //TODO  疑似还有一个消息传递
            return resultType;
            
        }
    }
}

