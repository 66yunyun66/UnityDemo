using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM
{
    ///<summary>
    /// 有限状态机的条件父类
    ///</summary>
    public abstract class FSMTrigger 
    {
        public FSMTriggerID triggerID;
        public FSMTrigger()
        {
            // 无参构造函数
            Init();

        }

        public abstract void Init();

        public abstract bool Handle(FSMBase fSMBase);
       
        
    }
    
} 
