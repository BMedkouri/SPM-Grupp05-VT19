using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    // Attributes
    [SerializeField] protected float jumpHeight;              // 7f
    [SerializeField] protected float acceleration;            // 14f
    //[SerializeField] protected float deceleration;            // 14f 
    [SerializeField] protected float turnSpeedModifier;       // 5f

    protected Player owner;

    // Methods
    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
    }

    public override void Enter()
    {

    }

    public override void HandleUpdate()
    {
        owner.PlayerInput(jumpHeight, acceleration, turnSpeedModifier);
    }
}
