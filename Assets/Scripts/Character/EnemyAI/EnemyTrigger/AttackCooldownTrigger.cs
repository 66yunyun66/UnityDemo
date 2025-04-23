using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    ///
    ///</summary>
    public class AttackCooldownTrigger : FSMTrigger
    {
        private float timer = 0;
        private float cdTimer = 3f;
        public override bool Handle(FSMBase fSMBase)
        {
            timer += Time.deltaTime;
            if (timer >= cdTimer) 
            {
                timer = 0;
                return true;
                
            }
            return false;
        }

        public override void Init()
        {
            triggerID = FSMTriggerID.AttackCooldown;
        }
    }

} 
