using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// ËÀÍö×´Ì¬
    ///</summary>
    public class DeadState : FSMState
    {
        public override void Init()
        {
            stateID = FSMStateID.Dead;
        }
        public override void EnterState(FSMBase fSMBase)
        {
            base.EnterState(fSMBase);
            fSMBase.enabled = false;
        }
        public override void ExitState(FSMBase fSMBase)
        {
            base.ExitState(fSMBase);
            fSMBase.enabled = true;
        }
    }

} 
