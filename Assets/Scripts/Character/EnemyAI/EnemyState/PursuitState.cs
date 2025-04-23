using Character.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace  AI.FSM{
    ///<summary>
    /// ׷����Ϊ
    ///</summary>
    public class PursuitState : FSMState
    {
        private NavMeshAgent agent;
        public override void Init()
        {
            // ��ʼ�����������޲ι��캯�����Զ�����
            // ��ҪĿ���Ǹ���ǰ״̬��һ��״̬idֵ
            stateID = FSMStateID.Pursuit;
        }
        public override void EnterState(FSMBase fSMBase)
        {
            
            base.EnterState(fSMBase);
            // �����״̬������Ҫ������ƶ���


            // �ƶ�---navagent.setpos
            agent = fSMBase.GetComponent<NavMeshAgent>();
            agent.stoppingDistance = 2f;

            // ����--- animator.setBool(FSMBase.anim.parm.run,true)
            fSMBase.animator.SetBool(CharacterAnimationParam.run, true);
        }

        public override void ExitState(FSMBase fSMBase)
        {
            base.ExitState(fSMBase);
            // �뿪׷��״̬---

            // ֹͣ�ƶ�



            // ֹͣ�����ƶ�����
            fSMBase.animator.SetBool(CharacterAnimationParam.run, false);
        }
        public override void ActiveState(FSMBase fSMBase)
        {
            base.ActiveState(fSMBase);
            agent.SetDestination(fSMBase.player.position);
            
        }
    }

} 
