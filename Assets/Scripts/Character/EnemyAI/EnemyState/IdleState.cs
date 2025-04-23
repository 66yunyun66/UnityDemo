using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    ///
    ///</summary>
    public class IdleState : FSMState
    {
        private Animator animator;
        public override void Init()
        {
            stateID = FSMStateID.Idle;
        }
        public override void EnterState(FSMBase fSMBase)
        {
            base.EnterState(fSMBase);
            //fSMBase.animator.SetBool(fSMBase.characterValue.aniParm)
        }
        public override void ExitState(FSMBase fSMBase)
        {
            base.ExitState(fSMBase);
        }

    }

} 
