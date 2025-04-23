using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Character.Control{
    ///<summary>
    ///
    ///</summary>
    public class DefendController : MonoBehaviour
    {
        
        private WeaponLight weaponLight;

        private void Awake()
        {
            weaponLight = GetComponent<WeaponLight>();
        }
        public void DefendSuccess()
        {
            weaponLight.SetEmission();
        }
    }
    
} 
