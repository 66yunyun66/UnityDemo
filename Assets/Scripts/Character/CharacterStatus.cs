using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// 完成角色的状态
    ///</summary>
    public class CharacterStatus : MonoBehaviour
    {
        private Animator _animator;
        
        public float HP = 100;
        public float VP = 100;
        public float XP = 0;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void Damage(float damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                Die();
            }
        }

        private void Die()
        {
            _animator.SetBool(CharacterAnimationParam.die, true);
            Destroy(this, 3f);
        }
    }
    
} 
