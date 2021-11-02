using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class NodeBase 
    {
        protected NODE_TYPE nodeType;//节点类型
        private int nodeIndex;//节点序列
        private int nodeId;//节点ID
        private int entituId;//EntityID
        private int priority;//权重

        protected NODE_STATUS nodeStatus = NODE_STATUS.READY;

        public NodeBase() { }

        protected void SetNodeType(NODE_TYPE nodeType)
        {
            this.nodeType = nodeType;
        }

        public  NODE_TYPE NodeType
        {
            get { return nodeType; }
        }

        public int NodeIndex
        {
            get { return nodeIndex; }
            set { nodeIndex = value; }
        }

        public int NodeId
        {
            get { return nodeId; }
            set { nodeId = value; }
        }

        public int EntityId
        {
            get { return entituId; }
            set { nodeId = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        /// <summary>
        /// 进入节点
        /// </summary>
        public virtual void OnEnter() { }
        /// <summary>
        /// 退出节点
        /// </summary>
        public virtual void OnExit() { }

        public abstract ResultType Execute();

        //执行Execute的前置方法，在Execute()方法的第一行执行
        public void Preposition()
        {
            if (nodeStatus == NODE_STATUS.READY)
            {
                nodeStatus = NODE_STATUS.RUNNING;
                OnEnter();
            }
        }
        /// <summary>
        /// 执行Execute的后置方法，在Execute()方法的return前调用
        /// </summary>
        /// <param name="resultType"></param>
        public void PostPosition(ResultType resultType)
        {
            if (resultType != ResultType.Running)
            {
                nodeStatus = NODE_STATUS.READY;
                OnExit();
            }
        }
        
    }

}

