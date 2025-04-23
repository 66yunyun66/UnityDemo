using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// ʵ�ֵ���������ʱ����ɫ���Ʋ���Emission������������ر�
    ///</summary>
    public class WeaponLight : MonoBehaviour
    {

        //// ��ȡ������Ĳ���
        [SerializeField]
        private Renderer renderer;
        //[SerializeField]
        //private Material material;

        public void SetEmission()
        {
         
            StartCoroutine(DelayEmission());
        }

        IEnumerator DelayEmission()
        {
            renderer.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
            renderer.material.DisableKeyword("_EMISSION");
        }


        
    }
    
} 
