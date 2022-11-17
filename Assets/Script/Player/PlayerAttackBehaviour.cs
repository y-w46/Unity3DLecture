using UnityEngine;
using UnityEngine.EventSystems;

namespace Attack1
{
    public class PlayerAttackBehaviour : StateMachineBehaviour
    {
        private PlayerController playerController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerController = animator.GetComponentInParent<PlayerController>();

            ExecuteEvents.Execute<IWeaponControll>(
                target: playerController.WeaponGameObject,
                eventData: null,
                functor: (reciever, eventData) => reciever.EnableWeaponCollider()
                );
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ExecuteEvents.Execute<IWeaponControll>(
                target: playerController.WeaponGameObject,
                eventData: null,
                functor: (reciever, eventData) => reciever.DisableWeaponCollider()
                );
        }
    }
}

