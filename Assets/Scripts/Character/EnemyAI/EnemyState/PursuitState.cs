using Character.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace  AI.FSM{
    ///<summary>
    /// 追击行为
    ///</summary>
    public class PursuitState : FSMState
    {
        private NavMeshAgent agent;
        public override void Init()
        {
            // 初始化函数，在无参构造函数中自动调用
            // 主要目的是给当前状态赋一个状态id值
            stateID = FSMStateID.Pursuit;
        }
        public override void EnterState(FSMBase fSMBase)
        {
            
            base.EnterState(fSMBase);
            // 进入该状态，则需要向玩家移动。


            // 移动---navagent.setpos
            agent = fSMBase.GetComponent<NavMeshAgent>();
            agent.stoppingDistance = 2f;

            // 动画--- animator.setBool(FSMBase.anim.parm.run,true)
            fSMBase.animator.SetBool(CharacterAnimationParam.run, true);
        }

        public override void ExitState(FSMBase fSMBase)
        {
            base.ExitState(fSMBase);
            // 离开追击状态---

            // 停止移动



            // 停止播放移动动画
            fSMBase.animator.SetBool(CharacterAnimationParam.run, false);
        }
        public override void ActiveState(FSMBase fSMBase)
        {
            base.ActiveState(fSMBase);
            agent.SetDestination(fSMBase.player.position);
            
        }
    }

} 
