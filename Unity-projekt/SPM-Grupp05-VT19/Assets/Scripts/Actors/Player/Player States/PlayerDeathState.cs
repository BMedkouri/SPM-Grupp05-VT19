using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDeathState")]
public class PlayerDeathState : PlayerBaseState
{
    // Methods
    public override void Enter()
    {
        //base.Enter();
        owner.GetComponent<Renderer>().enabled = false;
        //Plays animation
        //owner.animator.Play("PlayerDeathAnimation");
        //owner.destroyPlayer();
    }

    public override void HandleUpdate()
    {
        
    }
}
