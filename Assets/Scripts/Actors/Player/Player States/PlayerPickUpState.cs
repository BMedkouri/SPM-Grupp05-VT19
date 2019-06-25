//Author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerPickUpState")]
public class PlayerPickUpState : PlayerOnGroundState
{
    public override void Enter()
    {
        owner.Animator.SetTrigger("PickUp");
        owner.PlayerEquipmentHandler.EquippedWeapon.SetActive(false);
    }

    public override void HandleUpdate() { }

    public override void Exit()
    {
        owner.PlayerEquipmentHandler.EquippedWeapon.SetActive(true);
    }
}
