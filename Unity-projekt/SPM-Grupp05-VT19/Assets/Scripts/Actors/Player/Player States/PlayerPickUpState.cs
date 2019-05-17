//Author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerPickUpState")]
public class PlayerPickUpState : PlayerOnGroundState
{
    public override void Enter()
    {
        base.Enter();
        owner.Animator.SetTrigger("PickUp");
        owner.ActiveWeaponGameObject.SetActive(false);
    }

    public override void HandleUpdate() { }
}
