using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// ��������ײ��Ŀ���
    ///</summary>
    public class ColliderEnter : MonoBehaviour
    {
        
        public Collider collider;

        public void SetState(int isEnable)
        {
            collider.enabled = isEnable == 1;
        }

    }
    
} 
