using ns;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// ��ɵ��˹����߼�����������ű�
    ///</summary>
    public class ReachTargetTrigger : FSMTrigger
    {
        public override bool Handle(FSMBase fSMBase)
        {
            //return If(Vector3.Distance())
            return Vector3.Distance(fSMBase.transform.position,fSMBase.player.position)<=2;
        }

        public override void Init()
        {
            triggerID = FSMTriggerID.ReachTarget;
        }
    }

} 
