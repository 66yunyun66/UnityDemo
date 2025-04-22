using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace  Character.Control{
    ///<summary>
    /// 完成输入数据的收集
    ///</summary>
    public class InputData : MonoBehaviour
    {
        public VariableJoystick moveJoystick;
        
        // 创建事件，用于触发其他逻辑。
        public event Action<Vector3> inputEvent;
        
        [SerializeField]
        private float rotationSpeed = 20f;
        private Animator animator;
        private bool isMoving = false;
        private Quaternion targetRotation; // 目标旋转角度 
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        // 通过update函数不断收集输入信息，并保存

        private void FixedUpdate()
        {
            

            Vector3 input = new Vector3(moveJoystick.Horizontal,0 ,moveJoystick.Vertical);
            Move(input);
            if (input != Vector3.zero)
            {
                // 计算目标朝向角度 


                input = Camera.main.transform.TransformDirection(input);
                targetRotation = Quaternion.LookRotation(input.normalized);
                // 平滑插值旋转 
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

      

        private void Move(Vector3 direction)
        {
            
            // 如果输入不为0，则说明有输入，需要处理输入带来的不同逻辑
            if (direction != Vector3.zero)
            {
                inputEvent?.Invoke(direction);
                isMoving = true;
                //print(direction);
            }
            else if (isMoving && direction == Vector3.zero)
            {
                animator.SetBool(CharacterAnimationParam.run, false);
                //print(direction);
                isMoving = false;
            }
        }

    }
    
} 
