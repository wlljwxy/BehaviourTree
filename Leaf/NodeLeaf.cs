using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    [System.Serializable]
    public class NodeLeaf : NodeBase
    {
        public NodeLeaf() : base()
        {

        }
        public override ResultType Execute()
        {
            return ResultType.Fail;
        }
    }
}

