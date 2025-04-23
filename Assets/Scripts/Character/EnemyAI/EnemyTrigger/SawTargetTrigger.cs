using Character.Control;
using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 追击的条件，存放在待机idle状态中
    ///</summary>
    public class SawTargetTrigger : FSMTrigger
    {
        public override bool Handle(FSMBase fSMBase)
        {
            
            return Vector3.Distance(fSMBase.transform.position,
                fSMBase.player.transform.position) < 10f &&
                fSMBase.player.GetComponent<CharacterStatus>().HP > 0
                ;
            

        }

        public override void Init()
        {
            // 初始化状态条件的ID，在无参构造函数中自动调用，给该脚本确定的状态条件ID
            
            // 发现敌人条件
            triggerID = FSMTriggerID.SawTarget;
        }
        
    }

} 
