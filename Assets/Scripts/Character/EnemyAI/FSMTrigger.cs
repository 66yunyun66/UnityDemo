using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM
{
    ///<summary>
    /// ����״̬������������
    ///</summary>
    public abstract class FSMTrigger 
    {
        public FSMTriggerID triggerID;
        public FSMTrigger()
        {
            // �޲ι��캯��
            Init();

        }

        public abstract void Init();

        public abstract bool Handle(FSMBase fSMBase);
       
        
    }
    
} 
