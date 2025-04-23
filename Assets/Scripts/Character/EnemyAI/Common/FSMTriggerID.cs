using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 条件编号
    ///</summary>
    public enum FSMTriggerID 
    {
        /// <summary>
        /// 没有生命
        /// </summary>
        NoHealth,
        /// <summary>
        /// 发现目标
        /// </summary>
        SawTarget,
        /// <summary>
        /// 到达目标
        /// </summary>
        ReachTarget,
        /// <summary>
        /// 目标被击杀
        /// </summary>
        KilledTarget,
        /// <summary>
        /// 超出攻击范围
        /// </summary>
        WithoutAttackRange,
        /// <summary>
        /// 丢失目标
        /// </summary>
        LoseTarget,
        /// <summary>
        /// 完成巡逻
        /// </summary>
        CompletePatrol,
        /// <summary>
        /// 攻击后冷却状态
        /// </summary>
        AttackCooldown,
        /// <summary>
        /// 判定是否攻击了
        /// </summary>
        IsAttacked


    }
    
} 
