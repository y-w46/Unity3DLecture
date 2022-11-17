using UnityEngine;
using UnityEngine.EventSystems;

namespace Attack1
{
    public interface IWeaponControll : IEventSystemHandler
    {
        void EnableWeaponCollider();

        void DisableWeaponCollider();
    }
}
