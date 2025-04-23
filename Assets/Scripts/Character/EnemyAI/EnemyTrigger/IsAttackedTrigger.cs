using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 条件：是否已经进行了攻击
    ///</summary>
    public class IsAttackedTrigger : FSMTrigger
    {
        private AttackingState state;

        public override bool Handle(FSMBase fSMBase)
        {
            
            if (state == null) 
                state = fSMBase.states.Find(s => s.stateID == FSMStateID.Attacking) as AttackingState;
            return state.haveAttacked;

        }

        public override void Init()
        {
            triggerID = FSMTriggerID.IsAttacked;
            
        }
    }

} 
