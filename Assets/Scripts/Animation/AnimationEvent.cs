using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Animation.Character{
    ///<summary>
    /// �����¼��࣬�������¼��������ŵ�ĳһִ֡��ĳЩ����
    ///</summary>
    public class AnimationEvent : MonoBehaviour
    {
        private Animator animator;
        public event Action action;
        private void Awake()
        {
            // ���ص���ģ����
            animator = GetComponentInChildren<Animator>();
        }
        /// <summary>
        /// ���������ŵ�ĳһ֡ʱȡ������״̬
        /// </summary>
        /// <param name="animationName"></param>
        public void OnCancel(string animationName)
        {
            animator.SetBool(animationName, false);
        }


        public void OnAttack()
        {
            // �����ŵ�ĳЩ֡�����Զ�����¼�
            if (action != null) 
            {
                action();
            }
        }
    }
    
} 
