using Character.Control;
using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 杀死玩家后的条件。
    ///</summary>
    public class KilledTargetTrigger : FSMTrigger
    {
        public override bool Handle(FSMBase fSMBase)
        {
            return fSMBase.player.GetComponent<CharacterStatus>().HP <= 0;
        }

        public override void Init()
        {
            triggerID = FSMTriggerID.KilledTarget;
        }
    }

} 
