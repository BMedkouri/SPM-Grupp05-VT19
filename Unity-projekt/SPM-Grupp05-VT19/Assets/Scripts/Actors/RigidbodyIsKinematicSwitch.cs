//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// This script is called on from an actor's animator to enable and/or disable rigidbody components kinematic property.
/// When isKinematic is true, items don't react to collisions, and when it's false, they do.
/// 
/// Here's an example:
/// The player initiates an attack by pressing RT (right trigger) on the gamepad.
/// An animation starts playing, and inside of the animation, when we want the weapon to start detecting collisions,
/// we create an animation event that calls on EnableWeaponCollisions().
/// When we want the weapon to stop detecting collisions, we call on DisableWeaponCollisions().
/// </summary>
public class RigidbodyIsKinematicSwitch : MonoBehaviour
{
    #region Weapon
    private void EnableWeaponCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.PlayerEquipmentHandler.Weapon.Rigidbody.isKinematic = false;
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            GetComponentInChildren<Rigidbody>().isKinematic = false;
        }
    }

    private void DisableWeaponCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.PlayerEquipmentHandler.Weapon.Rigidbody.isKinematic = true;
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            GetComponentInChildren<Rigidbody>().isKinematic = true;
        }
    }
    #endregion Weapon

    #region Offhand
    private void EnableOffhandCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.PlayerEquipmentHandler.Offhand.Rigidbody.isKinematic = false;
        }
    }

    private void DisableOffhandCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.PlayerEquipmentHandler.Offhand.Rigidbody.isKinematic = true;
        }
    }
    #endregion Offhand
}
