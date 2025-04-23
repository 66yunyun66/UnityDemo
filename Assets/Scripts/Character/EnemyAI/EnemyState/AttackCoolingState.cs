using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    ///
    ///</summary>
    public class AttackCoolingState : FSMState
    {
        public override void Init()
        {
            stateID = FSMStateID.AttackCooling;
        }
       // 进入冷却状态，，目前什么也不做
    }

} 
