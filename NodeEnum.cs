using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BehaviourTree{
    

    /// <summary>
    /// 行为树节点类型
    /// </summary>
    public enum NODE_TYPE
    {
        //复合节点
        SELECT = 0,//选择节点
        SEQUENCE,//顺序节点
        RANDOM,//随机节点
        RANDOM_SEQUEUECE,//随机顺序节点
        RANDOM_PRIORITY,//随机权重节点
        PARALLEL,//并行选择节点
        PARALLEL_SELECT = 6,//并行选择节点
        PARALLEL_ALL,//并行执行所有节点
        IF_JUDEG,//判断节点

        //修饰节点
        DECORATOR_INVERTER = 100,//反相器
        DECORATOR_REPEAT,//重复器
        DECORATOR_RETURN_FAIL,//返回fail
        DECORATOR_RETURN_SUCCESS,//返回Success
        DECORATOR_UNTIL_FAIL,//直到fail
        DECORATOR_UNTIL_SUCCESS,//直到Success

        //叶子节点
        CONDITION = 200,//条件节点
        ACTION = 300,//行为节点

        //子树
        SUB_TREE = 1000,
    }

    /// <summary>
    /// 节点执行结果
    /// </summary>
    public enum ResultType
    {
        Fail,
        Success,
        Running
    }

    public enum NODE_STATUS
    {
        READY,
        RUNNING
    }
}
