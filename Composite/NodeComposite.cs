using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class NodeComposite :NodeBase
    {
        protected List<NodeBase> nodeChildList = new List<NodeBase>();

        public NodeComposite(NODE_TYPE nodeType) : base()
        {
            SetNodeType(nodeType);
        }

        public void AddNode(NodeBase node)
        {
            int count = nodeChildList.Count;
            node.NodeIndex = count;
            nodeChildList.Add(node);
        }

        public List<NodeBase> GetChilds()
        {
            return nodeChildList;
        }

        public override ResultType Execute()
        {
            return ResultType.Fail;
        }
    }
}

