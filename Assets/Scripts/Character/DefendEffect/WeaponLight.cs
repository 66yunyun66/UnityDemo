using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    /// 实现当弹反触发时，角色盾牌材质Emission开启，结束后关闭
    ///</summary>
    public class WeaponLight : MonoBehaviour
    {

        //// 获取子物体的材质
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
