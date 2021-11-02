using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 条件节点
    /// </summary>
    public abstract class ConditionNode:NodeLeaf
    {
        public ConditionNode() :base()
        {
            nodeType = NODE_TYPE.CONDITION;
        }
    }
}

