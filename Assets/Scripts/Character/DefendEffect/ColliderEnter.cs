using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// 完成玩家碰撞体的开关
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
