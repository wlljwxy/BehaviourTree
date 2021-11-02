using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 顺序节点
    /// </summary>
    public class SequenceNode : NodeComposite
    {
        private NodeBase lastRunningNode;
        public static string descript= "选择节点一次执行所有子节点  只要节点返回Success" +
            "继续执行后续节点   直到有一个节点返回Fail或者Running,停止执行后续节点" +
            "向父节点返回Fail或Running  如果所有节点都返回Success,则父节点返回Success" +
            " 注意如果返回Running,需要记住这个节点，下次直接从此节点开始执行";

        public SequenceNode() : base(NODE_TYPE.SEQUENCE)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
            lastRunningNode = null;
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
            for (int i = index; i < nodeChildList.Count; ++i)
            {
                NodeBase nodebase = nodeChildList[i];

                nodebase.Preposition();
                resultType = nodebase.Execute();
                nodebase.PostPosition(resultType);

                if (resultType == ResultType.Fail)
                {
                    break;
                }
                else if (resultType == ResultType.Success)
                {
                    continue;
                }
                else if (resultType == ResultType.Running)
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

