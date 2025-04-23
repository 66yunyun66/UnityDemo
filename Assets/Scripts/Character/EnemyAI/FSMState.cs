using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// ״̬����
    ///</summary>
    public abstract class FSMState
    {
        public FSMStateID stateID;

        // ��ž���״̬����Ľ�����������ID��Ӧ��״̬ID
        public Dictionary<FSMTriggerID, FSMStateID> maps;
        // ��ž���������б�
        public List<FSMTrigger> triggers;



        public FSMState()
        {
            Init();
            maps = new Dictionary<FSMTriggerID, FSMStateID>();
            triggers = new List<FSMTrigger>();
        }
        // ����ű���ʼ�������ڸ��Լ����Ӷ�Ӧ��stateID 
        public abstract void Init();


        public void AddMap(FSMTriggerID triggerID, FSMStateID stateID)
        {
            maps.Add(triggerID, stateID);
            // ������������

            CreateTrigger(triggerID);
        }
        private void CreateTrigger(FSMTriggerID triggerID)
        {
            // ������Ӧ��ӵ��ֵ䣬����������������

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
                    // �л�״̬
                    fSMBase.ChangeActiveState(stateID);
                }
                
                
                
            }
        }


        public virtual void EnterState(FSMBase fSMBase) { }
        public virtual void ActiveState(FSMBase fSMBase) { }
        public virtual void ExitState(FSMBase fSMBase) { }

    }
    
} 
