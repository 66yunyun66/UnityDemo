using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  AI.FSM{
    ///<summary>
    /// ×´Ì¬±àºÅ
    ///</summary>
    public enum FSMStateID 
    {
        /// <summary>
        /// ²»´æÔÚ¸Ã×´Ì¬
        /// </summary>
        None,
        /// <summary>
        /// Ä¬ÈÏ
        /// </summary>
        Default,
        /// <summary>
        /// ËÀÍö
        /// </summary>
        Dead,
        /// <summary>
        /// ÏÐÖÃ
        /// </summary>
        Idle,
        /// <summary>
        /// ×·Öð
        /// </summary>
        Pursuit,
        /// <summary>
        /// ¹¥»÷
        /// </summary>
        Attacking,
        /// <summary>
        /// Ñ²Âß
        /// </summary>
        Patrlling,

        /// <summary>
        /// ¹¥»÷ÀäÈ´×´Ì¬
        /// </summary>
        AttackCooling


        
    
    }
    
} 
