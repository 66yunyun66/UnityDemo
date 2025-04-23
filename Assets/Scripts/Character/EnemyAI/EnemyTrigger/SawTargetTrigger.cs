using Character.Control;
using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// ׷��������������ڴ���idle״̬��
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
            // ��ʼ��״̬������ID�����޲ι��캯�����Զ����ã����ýű�ȷ����״̬����ID
            
            // ���ֵ�������
            triggerID = FSMTriggerID.SawTarget;
        }
        
    }

} 
