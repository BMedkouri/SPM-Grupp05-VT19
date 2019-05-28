﻿//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDeathState")]
public class PlayerDeathState : PlayerBaseState
{
    // Methods
    public override void Enter()
    {
        owner.Animator.SetTrigger("Death");
    }

    public override void HandleUpdate() { }
}
