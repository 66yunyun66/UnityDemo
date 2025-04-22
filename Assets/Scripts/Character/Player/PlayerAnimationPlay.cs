using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// 完成玩家动画播放
    ///</summary>
    public class PlayerAnimationPlay : MonoBehaviour
    {
        private Animator animator;
        private void Awake()
        {
            
            animator = GetComponentInChildren<Animator>();
        }

        public void animPlay(Vector3 dir)
        {
            if(dir != Vector3.zero)
            {
                animator.SetBool(CharacterAnimationParam.run, true);
                //print(dir);
            }
        }
      
    }
    
} 
