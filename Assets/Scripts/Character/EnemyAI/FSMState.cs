using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// 状态基类
    ///</summary>
    public abstract class FSMState
    {
        public FSMStateID stateID;

        // 存放具体状态子类的接下来的条件ID对应的状态ID
        public Dictionary<FSMTriggerID, FSMStateID> maps;
        // 存放具体的条件列表
        public List<FSMTrigger> triggers;



        public FSMState()
        {
            Init();
            maps = new Dictionary<FSMTriggerID, FSMStateID>();
            triggers = new List<FSMTrigger>();
        }
        // 具体脚本初始化，用于给自己附加对应的stateID 
        public abstract void Init();


        public void AddMap(FSMTriggerID triggerID, FSMStateID stateID)
        {
            maps.Add(triggerID, stateID);
            // 创建条件对象

            CreateTrigger(triggerID);
        }
        private void CreateTrigger(FSMTriggerID triggerID)
        {
            // 遍历对应添加的字典，反射出具体的条件类

            Type type = Type.GetType("AI.FSM." + triggerID + "Trigger");
            //Debug.Log(triggerID);
            triggers.Add(Activator.CreateInstance(type) as FSMTrigger);
            
        }


        public void SelectTrigger(FSMBase fSMBase)
        {
            for (int i = 0; i < triggers.Count; i++)
            {
                if (triggers[i].Handle(fSMBase))
                {
                    FSMStateID stateID = maps[triggers[i].triggerID];
                    // 切换状态
                    fSMBase.ChangeActiveState(stateID);
                }
                
                
                
            }
        }


        public virtual void EnterState(FSMBase fSMBase) { }
        public virtual void ActiveState(FSMBase fSMBase) { }
        public virtual void ExitState(FSMBase fSMBase) { }

    }
    
} 
