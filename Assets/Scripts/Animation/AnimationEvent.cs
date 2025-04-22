using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Animation.Character{
    ///<summary>
    /// 动画事件类，处理动画事件，当播放到某一帧执行某些方法
    ///</summary>
    public class AnimationEvent : MonoBehaviour
    {
        private Animator animator;
        public event Action action;
        private void Awake()
        {
            // 挂载到非模型上
            animator = GetComponentInChildren<Animator>();
        }
        /// <summary>
        /// 当动画播放到某一帧时取消播放状态
        /// </summary>
        /// <param name="animationName"></param>
        public void OnCancel(string animationName)
        {
            animator.SetBool(animationName, false);
        }


        public void OnAttack()
        {
            // 当播放到某些帧调用自定义的事件
            if (action != null) 
            {
                action();
            }
        }
    }
    
} 
