//Author: Bilal El Medkouri

using UnityEngine;

public class RigidBodyIsKinematicSwitch : MonoBehaviour
{
    private Weapon weapon;
    private Offhand offhand;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            weapon = Player.PlayerReference.PlayerEquipmentHandler.Weapon;
            offhand = Player.PlayerReference.PlayerEquipmentHandler.Offhand;
        }
    }

    private void EnableWeaponCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            weapon.Rigidbody.isKinematic = false;
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            // TODO: Like above but for an enemy
        }
    }

    private void DisableWeaponCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            weapon.Rigidbody.isKinematic = true;
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            // TODO: Like above but for an enemy
        }
    }

    private void EnableOffhandCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            offhand.Rigidbody.isKinematic = false;
        }
    }

    private void DisableOffhandCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            offhand.Rigidbody.isKinematic = true;
        }
    }
}
