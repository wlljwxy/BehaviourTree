using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 随机节点
    /// </summary>
    public class RandomNode :NodeComposite
    {
        private NodeBase lastRunningNode;
        private int[] idArr = null;
        private int _randomCount = 0;
        private System.Random random;
        public static string descript = "随机执行节点，只要有一个节点返回成功，它就会返回成功，不在执行" +
            "后续节点  如果所有节点都返回fail,则它返回Fail,否则返回Runnings";
    
        public RandomNode() : base(NODE_TYPE.RANDOM)
        {
            random = new System.Random();
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
            for (int i = 0; i < nodeChildList.Count; ++i)
            {
                if (index < 0)
                {
                    index = GetRandom();
                }
                NodeBase nodebase = nodeChildList[index];
                index = -1;

                nodebase.Preposition();
                resultType = nodebase.Execute();
                nodebase.PostPosition(resultType);

                if (resultType == ResultType.Fail)
                {
                    continue;
                }
                else if (resultType == ResultType.Success)
                {
                    break;
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


        private int GetRandom()
        {
            if (null == idArr)
            {
                idArr = new int[nodeChildList.Count];
                for (int i = 0; i < idArr.Length; i++)
                {
                    idArr[i] = i;
                }
            }
            int count = idArr.Length - 1;
            int index = random.Next(0, idArr.Length - _randomCount);
            int value = idArr[index];
            idArr[index] = idArr[count - _randomCount];
            ++_randomCount;

            return value;

        }
    }
}

