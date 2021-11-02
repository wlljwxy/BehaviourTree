using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class DecoratorNode : NodeComposite
    {
        public DecoratorNode(NODE_TYPE nodeType) : base(nodeType)
        {

        }

        /// <summary>
        /// 修饰节点不能独立存在，其作用是对子节点进行修饰，一得到我们所希望的结果
        /// 修饰节点常用的几个类型
        /// 反相器  重复器 
        /// Return Failure  执行到此节点是返回失败
        /// Return Success  执行到此节点是返回成功
        /// Until Failure   一直执行，直到失败
        /// Until Success   一直执行，直到成功
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute()
        {
            return ResultType.Success;
        }
    }
}

