using Character.Control;
//using Demo.animation;
using ns;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Timeline.Actions;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// ����״̬��
    ///</summary>
    public class AttackingState : FSMState
    {
        
        private CharacterStatus playerStatus;
        private FSMBase fSMBase;
        public bool haveAttacked = false;
        public override void Init()
        {

           // ��ʼ�������״̬id
           stateID = FSMStateID.Attacking;

        }
        public override void EnterState(FSMBase fSMBase)
        {
            base.EnterState(fSMBase);
            this.fSMBase = fSMBase;
            // ��������״̬,��ʼ���������ϵĶ����¼�����
            
            haveAttacked = false;
            // ��ʼ��������ϵ�״̬��
            playerStatus = fSMBase.player.GetComponent<CharacterStatus>();
            // ��ʼ��������

            fSMBase.animator.SetBool(CharacterAnimationParam.attack, true);
            fSMBase.StartCoroutine(DelayHaveAttack());
            
            
        }
        public override void ActiveState(FSMBase fSMBase)
        {
            base.ActiveState(fSMBase);
        }

        public override void ExitState(FSMBase fSMBase)
        {
            base.ExitState(fSMBase);
            // ����뿪��״̬
            // ֹͣ��������
            fSMBase.animator.SetBool(CharacterAnimationParam.attack, false);
        }

        IEnumerator DelayHaveAttack()
        {
            yield return new WaitForSeconds(0.5f);
            SetAttacked();
        }
        private void SetAttacked()
        {
            //״̬ȡ��
            haveAttacked = !haveAttacked;
        }

        
    }

} 
