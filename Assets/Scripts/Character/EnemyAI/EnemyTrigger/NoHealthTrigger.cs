using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 没有生命条件
    ///</summary>
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool Handle(FSMBase fSMBase)
        {
            return fSMBase.characterValue.HP <= 0;
        }

        public override void Init()
        {
            triggerID = FSMTriggerID.NoHealth;
        }
    }

} 
