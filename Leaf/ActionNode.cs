using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 行为节点
    /// </summary>
    public abstract class ActionNode:NodeLeaf
    {
        public ActionNode() : base()
        {
            nodeType = NODE_TYPE.ACTION;
        }
    }
}

