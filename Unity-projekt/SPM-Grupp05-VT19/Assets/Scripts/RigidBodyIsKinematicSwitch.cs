//Author: Bilal El Medkouri

using UnityEngine;

public class RigidBodyIsKinematicSwitch : MonoBehaviour
{
    private void EnableWeaponCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.ActiveWeaponWeapon.Rigidbody.isKinematic = false;
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
            Player.PlayerReference.ActiveWeaponWeapon.Rigidbody.isKinematic = true;
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
            Player.PlayerReference.ActiveOffhandOffhand.Rigidbody.isKinematic = false;
        }
    }

    private void DisableOffhandCollisions()
    {
        if (gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.ActiveOffhandOffhand.Rigidbody.isKinematic = true;
        }
    }
}
