using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class ParallelNode : NodeComposite
    {
        public static string descript = "并行节点同时执行所有节点，直到一个节点返回Fail" +
            "或者全部节点都返回Success才向父节点返回Faill或者Success,并终止执行其他节点" +
            "其他情况返回Running";

        private int _runningNode = 0;
        public ParallelNode() : base(NODE_TYPE.PARALLEL) { }

        public override void OnEnter()
        {
            base.OnEnter();
            _runningNode = 0;
        }

        public override void OnExit()
        {
            base.OnExit();
            for (int i = 0; i < nodeChildList.Count; i++)
            {
                int value = (1 << i);
                if ((_runningNode & value) > 0)
                {
                    NodeBase nodebase = nodeChildList[i];
                    nodebase.PostPosition(ResultType.Fail);
                }
            }
        }

        public override ResultType Execute()
        {
            ResultType resultType = ResultType.Fail;

            int successCount = 0;
            for (int i = 0; i < nodeChildList.Count; ++i)
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
                    ++successCount;
                    continue;
                }
                else if (resultType == ResultType.Running)
                {
                    _runningNode |= (1 << i);
                    continue;
                }
            }
            if (resultType != ResultType.Fail)
            {
                resultType = (successCount >= nodeChildList.Count) ? ResultType.Success : ResultType.Running;

            }
            //TODO 疑似还有消息要发送
            return resultType;
        }
    }
}

