//using Demo.animation;
using Character.Control;
using ns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM {
    ///<summary>
    /// 状态机
    ///</summary>
    public class FSMBase : MonoBehaviour
    {
        #region 脚本生命周期
        private void Start()
        {
            ConfigFSM();
            InitDefaultState();
            animator = GetComponentInChildren<Animator>();
            characterValue = GetComponent<CharacterStatus>();
            //animationParam = GetComponentInChildren<CharacterAnimationParam>();
            animationParam = new CharacterAnimationParam();
        }
        // 每帧处理的逻辑
        public void Update()
        {
            // 判断当前状态条件
            currentState.SelectTrigger(this);
            // 执行当前状态逻辑
            currentState.ActiveState(this);
        }
        #endregion

        #region 状态机自身成员
        // 玩家位置信息
        public Transform player;


        // 敌人自身动画控制器
        public CharacterAnimationParam animationParam;

        // 状态列表
        public List<FSMState> states;

        // 配置状态机
        //--创建状态对象
        //--设置状态（AddMap)
        [Tooltip("默认状态编号")]
        public FSMStateID defaultStateID;

        // 默认状态
        private FSMState defaultState;

        // 当前状态
        [SerializeField]
        private FSMState currentState;

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public CharacterStatus characterValue;
        #endregion

        #region 为成员赋值的功能

        // 配置状态机
        private void ConfigFSM()
        {
            states = new List<FSMState>();
            IdleState idleState = new IdleState();
            idleState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            states.Add(idleState);

            DeadState deadState = new DeadState();
            states.Add(deadState);

            PursuitState pursuitState = new PursuitState();
            idleState.AddMap(FSMTriggerID.SawTarget,FSMStateID.Pursuit);
            states.Add(pursuitState);
            idleState.AddMap(FSMTriggerID.ReachTarget,FSMStateID.Attacking);

            pursuitState.AddMap(FSMTriggerID.LoseTarget,FSMStateID.Idle);
            pursuitState.AddMap(FSMTriggerID.NoHealth,FSMStateID.Dead);

            AttackingState attackingState = new AttackingState();
            pursuitState.AddMap(FSMTriggerID.ReachTarget,FSMStateID.Attacking);
            states.Add(attackingState);

            attackingState.AddMap(FSMTriggerID.KilledTarget, FSMStateID.Idle);
            attackingState.AddMap(FSMTriggerID.IsAttacked,FSMStateID.AttackCooling);
            //attackingState.AddMap(FSMTriggerID.SawTarget, FSMStateID.Pursuit);
            AttackCoolingState attackCoolingState = new AttackCoolingState();
            attackCoolingState.AddMap(FSMTriggerID.AttackCooldown, FSMStateID.Idle);
            states.Add(attackCoolingState);




        }


        private void InitDefaultState()
        {
            defaultState = states.Find(s => s.stateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);
        }





        // 切换状态
        public void ChangeActiveState(FSMStateID stateID)
        {
            // 离开上一个状态
            currentState.ExitState(this);
            print(currentState.stateID);
            // 设置当前状态
            if (stateID == defaultStateID)
            {
                currentState = defaultState;
            }
            else
                currentState = states.Find(states => states.stateID == stateID);
            // 进入下一个状态
            currentState.EnterState(this);
            print(currentState.stateID);

        }
        #endregion

    }

}
