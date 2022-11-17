using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack1
{
    public class Weapon : MonoBehaviour, IWeaponControll
    {
        private Collider _weaponCollider;

        // Start is called before the first frame update
        void Start()
        {
            _weaponCollider = GetComponent<Collider>();
            _weaponCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void EnableWeaponCollider()
        {
            if (_weaponCollider != null)
            {
                _weaponCollider.enabled = true;
            }
        }

        public void DisableWeaponCollider()
        {
            if (_weaponCollider != null)
            {
                _weaponCollider.enabled = false;
            }
        }
    }
}



