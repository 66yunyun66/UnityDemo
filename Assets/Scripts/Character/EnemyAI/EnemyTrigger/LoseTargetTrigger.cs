using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 丢失目标条件类
    ///</summary>
    public class LoseTargetTrigger : FSMTrigger
    {
        public override bool Handle(FSMBase fSMBase)
        {
            return Vector3.Distance(fSMBase.transform.position,
                fSMBase.player.transform.position) >= 10f;
        }

        public override void Init()
        {
            triggerID = FSMTriggerID.LoseTarget;
        }
    }

} 
