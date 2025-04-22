using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;


namespace  Character.Control{
    ///<summary>
    /// 完成角色的移动功能，并提供移动的接口
    ///</summary>
    public class PlayerMove : MonoBehaviour
    {
        private CharacterController controller;
        [SerializeField]
        private float currentSpeed = 2f;
        
        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }
        public void HandleMovement(Vector3 direction)
        {
            Vector3 dir = Vector3.zero;
            if (controller.isGrounded)
            {
                
                dir.y = -2f; // 轻微下压力确保贴地 
                controller.Move(dir);
            }
            else
            {
                dir.y += -15 * Time.deltaTime;
                controller.Move(dir);
            }
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);


        }

       



    }
    
} 
