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
    /// ����������ݵ��ռ�
    ///</summary>
    public class InputData : MonoBehaviour
    {
        public VariableJoystick moveJoystick;
        [SerializeField]
        private float rotationSpeed = 20f;
        private Animator animator;

        private Quaternion targetRotation; // Ŀ����ת�Ƕ�

        #region �ۺϳ�Ա 
        private PlayerMove playerMove;  // ��ɫ�ƶ��ű����ṩ�ƶ��ӿ�
        private ColliderEnter colliderEnter; // ������ײ�����ýű����ṩ���ýӿ�
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
        // ͨ��update���������ռ�������Ϣ��������

        private void Start()
        {
            #region �ƶ�������
            var inputMoveSteam = this.UpdateAsObservable() // ֡�۲��ߣ�ѡ��ָ������
                .Select(_ => new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical));
            //.DistinctUntilChanged();// �����ظ�ֵ  ---  �˴���Ҫ���������˿��ܲ�������

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
            #region ����״̬������
            var inputDefendSteam = this.UpdateAsObservable() // ֡�۲���,ѡ��ָ������
                .Select(_ => Input.GetKey(KeyCode.Space))
                .DistinctUntilChanged()
                .Do(v => Debug.Log($"����״̬���: {v}"));// ȥ���ظ�ֵ


            inputDefendSteam.Subscribe(v =>
            {
                animator.SetBool(CharacterAnimationParam.defend, v);
                colliderEnter.SetState(v ? 1 : 0);

            }).AddTo(this);


            #endregion
            #region �����������
            // ���˹�����������ʹ����Ҷ�����ײ�����������
            
     var enemyAttackStream = colliderDefend.OnTriggerEnterAsObservable()
        .Where(collider => collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        .Select(_ => true) // ������ʼ��״̬Ϊ true 
        .Merge(
        colliderDefend.OnTriggerExitAsObservable() // ���������뿪�¼� 
            .Where(collider => collider.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            .Select(_ => false) // ����������״̬Ϊ false 
    );
            

            inputDefendSteam.CombineLatest(enemyAttackStream, (defense, attack) => defense && attack)
            .Where(canParry => canParry)
            .ThrottleFirst(TimeSpan.FromSeconds(0.5)) // ������ 
            .Subscribe(_ =>
            {
                Debug.Log("�����ɹ���");
                // ��������Ӳֱ�����Ӽ��Ʋ۵��߼� 
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
                // ����Ŀ�곯��Ƕ� 


                input = Camera.main.transform.TransformDirection(input);
                targetRotation = Quaternion.LookRotation(input.normalized);
                // ƽ����ֵ��ת 
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }


            //}


            //private void Move(Vector3 direction)
            //{

            //    // ������벻Ϊ0����˵�������룬��Ҫ������������Ĳ�ͬ�߼�
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
