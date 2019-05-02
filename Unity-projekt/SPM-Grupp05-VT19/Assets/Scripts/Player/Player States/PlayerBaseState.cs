using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    // Attributes
    [SerializeField] protected float jumpHeight;              // 7f
    [SerializeField] protected float acceleration;            // 14f
    [SerializeField] protected float turnSpeedModifier;       // 5f
    [SerializeField] protected Material material;
    protected Vector3 direction;

    protected Player owner;

    // Methods
    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
    }

    public override void Enter()
    {
        owner.renderer.material = material;
    }

    public override void HandleUpdate()
    {
        //Handles input
        PlayerInput();

        //Regeneration
        owner.Regeneration();

        //Invulnerability timer
        owner.InvulnerabilityCountdown();
    }

    private void PlayerInput()
    {
        //Takes input from player
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //owner.animator.SetFloat("Speed", direction.x);
        //owner.animator.SetFloat("Direction", direction.z);

        //Multiplies input with camera rotation (so that we move in accordance with the camera, and not the world coordinates)
        if (owner.collision.IsGrounded())
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, owner.collision.GetGroundRaycastHit().normal).normalized;
        }
        else
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, Vector3.up).normalized;
        }

        //Attack
        if (Input.GetAxisRaw("Right Trigger") == 1 && !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") && !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") && !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<AttackState>();
        }
        if (Input.GetButtonDown("Left Bumper") && !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") && !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") && !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<PlayerParryState>();
        }
        if(Input.GetAxisRaw("Left Trigger") == 1 && !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") && !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") && !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<PlayerLightState>();
        }
        //Movement
        if (direction != Vector3.zero)
        {
            owner.physics.Accelerate(direction, acceleration, turnSpeedModifier);
        }

        //Take damage - For testing purposes
        if (Input.GetButtonDown("Xbox A"))
        {
            owner.TakeDamage(10.0f);
            owner.LoseStamina(20.0f);
            owner.LoseEnergy(10.0f);
        }

        //Heal player - For testing purposes
        if (Input.GetButtonDown("Xbox Y"))
        {
            owner.RecoverHealth(10.0f);
            owner.RecoverStamina(15.0f);
            owner.RecoverEnergy(10.0f);
        }

        if (!owner.collision.IsGrounded())
        {
            owner.Transition<InAirState>();
        }
    }
   
    public Vector3 GetDirection()
    {
        return direction;
    }
}
