using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace  Character.Control{
    ///<summary>
    /// ����������ݵ��ռ�
    ///</summary>
    public class InputData : MonoBehaviour
    {
        public VariableJoystick moveJoystick;
        
        // �����¼������ڴ��������߼���
        public event Action<Vector3> inputEvent;
        
        [SerializeField]
        private float rotationSpeed = 20f;
        private Animator animator;
        private bool isMoving = false;
        private Quaternion targetRotation; // Ŀ����ת�Ƕ� 
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        // ͨ��update���������ռ�������Ϣ��������

        private void FixedUpdate()
        {
            

            Vector3 input = new Vector3(moveJoystick.Horizontal,0 ,moveJoystick.Vertical);
            Move(input);
            if (input != Vector3.zero)
            {
                // ����Ŀ�곯��Ƕ� 


                input = Camera.main.transform.TransformDirection(input);
                targetRotation = Quaternion.LookRotation(input.normalized);
                // ƽ����ֵ��ת 
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

      

        private void Move(Vector3 direction)
        {
            
            // ������벻Ϊ0����˵�������룬��Ҫ������������Ĳ�ͬ�߼�
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
