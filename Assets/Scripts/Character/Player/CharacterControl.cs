using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// 关联角色控制的所有脚本，处理相关脚本直接的数据传输
    ///</summary>
    public class CharacterControl : MonoBehaviour
    {
        private InputData data;
        private PlayerMove move;
        private PlayerAnimationPlay animationPlay;
        private void Awake()
        {
            data = GetComponent<InputData>();
            move = GetComponent<PlayerMove>();
            animationPlay = GetComponentInChildren<PlayerAnimationPlay>();
        }
        // 订阅事件
        private void OnEnable()
        {
            data.inputEvent += move.HandleMovement;
            data.inputEvent += animationPlay.animPlay;
        }







        // 取消订阅
        private void OnDisable()
        {
            data.inputEvent -= move.HandleMovement;
            data.inputEvent -= animationPlay.animPlay;
        }
    }
    
} 
