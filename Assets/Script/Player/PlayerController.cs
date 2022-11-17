using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _camera;

        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rollSpeed = 360f;

        private static readonly int IS_Move_HASH = Animator.StringToHash("IsMove");
        private static readonly int Attack_HASH = Animator.StringToHash("Attack");
        private static readonly int IS_Hit_HASH = Animator.StringToHash("ISHit");
        private static readonly int IS_Die = Animator.StringToHash("ISDie");

        #region Variables Weapon
        [SerializeField] private GameObject _weaponGameObject;
        public GameObject WeaponGameObject => _weaponGameObject;
        #endregion //Variables Weapon

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            ControlMove();
            ControlAttack();
        }

        private Vector3 GetMoveVector()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            Vector3 moveVector = Vector3.zero;
            moveVector.z = vertical;
            moveVector.x = horizontal;

            //
            Quaternion cameraRotate;
            cameraRotate = Quaternion.Euler(0f, _camera.eulerAngles.y, 0f);

            return cameraRotate * moveVector.normalized;
        }

        private void ControlMove()
        {
            var moveVector = GetMoveVector();
            var isMove = moveVector != Vector3.zero;

            if (_animator != null)
            {
                _animator.SetBool(IS_Move_HASH, isMove);
            }

            if (isMove)
            {
                transform.position += moveVector * Time.deltaTime * _moveSpeed;

                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(moveVector.x, 0f, moveVector.z));

                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * _rollSpeed);
            }
        }

        private void ControlAttack()
        {
            // 攻撃ボタンを押した
            if (_animator != null && Input.GetButtonDown("Fire1"))
            {
                _animator.SetTrigger(Attack_HASH);
            }
        }
    }
}

