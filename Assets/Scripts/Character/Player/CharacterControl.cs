using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// ������ɫ���Ƶ����нű���������ؽű�ֱ�ӵ����ݴ���
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
        // �����¼�
        private void OnEnable()
        {
            data.inputEvent += move.HandleMovement;
            data.inputEvent += animationPlay.animPlay;
        }







        // ȡ������
        private void OnDisable()
        {
            data.inputEvent -= move.HandleMovement;
            data.inputEvent -= animationPlay.animPlay;
        }
    }
    
} 
