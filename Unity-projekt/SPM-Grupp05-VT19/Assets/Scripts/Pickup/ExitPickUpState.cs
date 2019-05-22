//Author: Bilal El Medkouri

using UnityEngine;

public class ExitPickUpState : MonoBehaviour
{
    private void Bankai()
    {
        Player.PlayerReference.PlayerEquipmentHandler.EquippedWeaponID = 2;
    }

    private void ChangePlayerState()
    {
        Player.PlayerReference.Transition<PlayerOnGroundState>();
    }
}
