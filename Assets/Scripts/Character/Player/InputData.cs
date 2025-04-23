using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Character.Control
{
    ///<summary>
    /// 完成输入数据的收集
    ///</summary>
    public class InputData : MonoBehaviour
    {
        public VariableJoystick moveJoystick;
        [SerializeField]
        private float rotationSpeed = 20f;
        private Animator animator;

        private Quaternion targetRotation; // 目标旋转角度

        #region 聚合成员 
        private PlayerMove playerMove;  // 角色移动脚本，提供移动接口
        private ColliderEnter colliderEnter; // 盾牌碰撞体启用脚本，提供启用接口
        public Collider colliderDefend;
        public DefendController defendcontroller;

        #endregion
        private bool isDefending = false;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            playerMove = GetComponent<PlayerMove>();
            colliderEnter = GetComponent<ColliderEnter>();
        }
        // 通过update函数不断收集输入信息，并保存

        private void Start()
        {
            #region 移动输入检测
            var inputMoveSteam = this.UpdateAsObservable() // 帧观察者，选择指定数据
                .Select(_ => new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical));
            //.DistinctUntilChanged();// 过滤重复值  ---  此处不要，，过滤了可能不会跑了

            inputMoveSteam.Where(v => v != Vector3.zero)
                .Subscribe(v =>
                {
                    playerMove.HandleMovement(v);
                    Rorate(v);
                }).AddTo(this);
            inputMoveSteam.Subscribe(v =>
            {
                bool isMoving = v != Vector3.zero;
                animator.SetBool(CharacterAnimationParam.run, isMoving);

            }).AddTo(this);
            #endregion
            #region 弹反状态进入检测
            var inputDefendSteam = this.UpdateAsObservable() // 帧观察者,选择指定数据
                .Select(_ => Input.GetKey(KeyCode.Space))
                .DistinctUntilChanged()
                .Do(v => Debug.Log($"防御状态变更: {v}"));// 去掉重复值


            inputDefendSteam.Subscribe(v =>
            {
                animator.SetBool(CharacterAnimationParam.defend, v);
                colliderEnter.SetState(v ? 1 : 0);

            }).AddTo(this);


            #endregion
            #region 触发弹反检测
            // 敌人攻击数据流，使用玩家盾牌碰撞器检测数据流
            
     var enemyAttackStream = colliderDefend.OnTriggerEnterAsObservable()
        .Where(collider => collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        .Select(_ => true) // 攻击开始，状态为 true 
        .Merge(
        colliderDefend.OnTriggerExitAsObservable() // 监听武器离开事件 
            .Where(collider => collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            .Select(_ => false) // 攻击结束，状态为 false 
    );
            

            inputDefendSteam.CombineLatest(enemyAttackStream, (defense, attack) => defense && attack)
            .Where(canParry => canParry)
            .ThrottleFirst(TimeSpan.FromSeconds(0.5)) // 防连点 
            .Subscribe(_ =>
            {
                Debug.Log("弹反成功！");
                // 触发敌人硬直、增加架势槽等逻辑 
                defendcontroller.DefendSuccess();   
                
            })
            .AddTo(this);
        }
        #endregion


        //private void FixedUpdate()
        //{


        //    Vector3 input = new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical);
        //    Move(input);
        //    Rorate(input);
        //}

        private void Rorate(Vector3 input)
        {
            if (input != Vector3.zero)
            {
                // 计算目标朝向角度 


                input = Camera.main.transform.TransformDirection(input);
                targetRotation = Quaternion.LookRotation(input.normalized);
                // 平滑插值旋转 
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }


            //}


            //private void Move(Vector3 direction)
            //{

            //    // 如果输入不为0，则说明有输入，需要处理输入带来的不同逻辑
            //    if (direction != Vector3.zero)
            //    {
            //        inputEvent?.Invoke(direction);
            //        isMoving = true;
            //        //print(direction);
            //    }
            //    else if (isMoving && direction == Vector3.zero)
            //    {
            //        animator.SetBool(CharacterAnimationParam.run, false);
            //        //print(direction);
            //        isMoving = false;
            //    }
            //}

        }
    }
}
