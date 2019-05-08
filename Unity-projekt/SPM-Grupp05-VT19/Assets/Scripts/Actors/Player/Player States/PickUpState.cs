//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PickUpState")]
public class PickUpState : OnGroundState
{
    public override void Enter()
    {
        base.Enter();
        owner.animator.SetTrigger("PickUp");
        GameObject.FindGameObjectWithTag(owner.GetComponentInChildren<ActiveWeapon>().GetActiveWeaponName()).SetActive(false);
    }

    public override void HandleUpdate() { }
}
