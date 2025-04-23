//using Demo.animation;
using Character.Control;
using ns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM {
    ///<summary>
    /// ״̬��
    ///</summary>
    public class FSMBase : MonoBehaviour
    {
        #region �ű���������
        private void Start()
        {
            ConfigFSM();
            InitDefaultState();
            animator = GetComponentInChildren<Animator>();
            characterValue = GetComponent<CharacterStatus>();
            //animationParam = GetComponentInChildren<CharacterAnimationParam>();
            animationParam = new CharacterAnimationParam();
        }
        // ÿ֡������߼�
        public void Update()
        {
            // �жϵ�ǰ״̬����
            currentState.SelectTrigger(this);
            // ִ�е�ǰ״̬�߼�
            currentState.ActiveState(this);
        }
        #endregion

        #region ״̬�������Ա
        // ���λ����Ϣ
        public Transform player;


        // ����������������
        public CharacterAnimationParam animationParam;

        // ״̬�б�
        public List<FSMState> states;

        // ����״̬��
        //--����״̬����
        //--����״̬��AddMap)
        [Tooltip("Ĭ��״̬���")]
        public FSMStateID defaultStateID;

        // Ĭ��״̬
        private FSMState defaultState;

        // ��ǰ״̬
        [SerializeField]
        private FSMState currentState;

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public CharacterStatus characterValue;
        #endregion

        #region Ϊ��Ա��ֵ�Ĺ���

        // ����״̬��
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





        // �л�״̬
        public void ChangeActiveState(FSMStateID stateID)
        {
            // �뿪��һ��״̬
            currentState.ExitState(this);
            print(currentState.stateID);
            // ���õ�ǰ״̬
            if (stateID == defaultStateID)
            {
                currentState = defaultState;
            }
            else
                currentState = states.Find(states => states.stateID == stateID);
            // ������һ��״̬
            currentState.EnterState(this);
            print(currentState.stateID);

        }
        #endregion

    }

}
