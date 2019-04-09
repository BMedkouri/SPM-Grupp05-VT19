﻿using System.Collections;
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
        owner.currentStateAsString = this.ToString();
    }

    public override void HandleUpdate()
    {
        //Handles input
        PlayerInput();

        //Regeneration
        owner.HealthRegeneration();
    }

    private void PlayerInput()
    {
        //Takes input from player
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //Multiplies input with camera rotation (so that we move in accordance with the camera, and not the world coordinates)
        if (owner.IsGrounded())
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, owner.hitInfo.normal).normalized;
        }
        else
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, Vector3.up).normalized;
        }

        //Movement
        if (direction != Vector3.zero)
        {
            owner.physics.Accelerate(direction, acceleration, turnSpeedModifier);
        }

        //Take damage - For testing purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
            owner.TakeDamage(10.0f);
        }

        //Heal player - For testing purposes
        if (Input.GetKeyDown(KeyCode.L))
        {
            owner.RecoverHealth(10.0f);
        }
    }
}
