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
    /// 攻击状态类
    ///</summary>
    public class AttackingState : FSMState
    {
        
        private CharacterStatus playerStatus;
        private FSMBase fSMBase;
        public bool haveAttacked = false;
        public override void Init()
        {

           // 初始化该类的状态id
           stateID = FSMStateID.Attacking;

        }
        public override void EnterState(FSMBase fSMBase)
        {
            base.EnterState(fSMBase);
            this.fSMBase = fSMBase;
            // 如果进入该状态,初始化敌人身上的动画事件器。
            
            haveAttacked = false;
            // 初始化玩家身上的状态器
            playerStatus = fSMBase.player.GetComponent<CharacterStatus>();
            // 开始攻击动画

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
            // 如果离开该状态
            // 停止攻击动画
            fSMBase.animator.SetBool(CharacterAnimationParam.attack, false);
        }

        IEnumerator DelayHaveAttack()
        {
            yield return new WaitForSeconds(0.5f);
            SetAttacked();
        }
        private void SetAttacked()
        {
            //状态取反
            haveAttacked = !haveAttacked;
        }

        
    }

} 
