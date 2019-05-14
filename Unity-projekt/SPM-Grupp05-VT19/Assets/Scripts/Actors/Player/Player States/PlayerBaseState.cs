using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Bilal El Medkouri
 * @co-author Anders Ragnar
 * 
 * The base to all playerstates
 */
public class PlayerBaseState : State
{
    protected Vector3 direction;
    protected Player owner;

    // Methods
    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
        
    }

    public override void HandleUpdate()
    {
        //Handles input
        PlayerInput();

        //Regeneration
        owner.Regeneration();
    }

    /// <summary>
    /// This method takes the input from the player, as movement and hits with weapon.
    /// It also makes the input direction acts from the cameras point of view with Vector3.ProjectOnPlane
    /// </summary>
    private void PlayerInput()
    {
        //Takes input from player
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Multiplies input with camera rotation (so that we move in accordance with the camera, and not the world coordinates)
        if (owner.collision.IsGrounded())
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, owner.collision.GetGroundRaycastHit().normal).normalized;
        }
        else
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, Vector3.up).normalized;
        }
        //Movement
        if (direction != Vector3.zero)
        {
            owner.physics.Accelerate(direction, owner.Acceleration);

            // Projects velocity onto the ground planes normal
            if(Vector3.Angle(owner.collision.GetGroundRaycastHit().normal, Vector3.up) <= 50)
            {
                owner.physics.SetVelocity(Vector3.ProjectOnPlane(owner.physics.GetVelocity(), owner.collision.GetGroundRaycastHit().normal));
            }
            
            //Rotates the players mesh with the direction
            owner.rotate.Rotate(direction);
        }
        
        //Heal player - For testing purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
            owner.RecoverStamina(15.0f);
            owner.RecoverEnergy(10.0f);
        }

        // Temporary 
        if (Input.GetKeyDown(KeyCode.V))
        {
            owner.transform.position += Vector3.up * 5f;
        }

        //Attack
        if (Input.GetAxisRaw("Right Trigger") == 1 &&
            !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") &&
            !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") &&
            !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<AttackState>();
        }
        if (Input.GetAxisRaw("Left Trigger") == 1 &&
            !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") &&
            !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") &&
            !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<PlayerParryState>();
        }
        if (Input.GetButtonDown("Left Bumper") &&
            !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") &&
            !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") &&
            !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<PlayerLightState>();
        }

        if (!owner.collision.IsGrounded())
        {
            owner.Transition<InAirState>();
        }

        owner.animator.SetFloat("Speed", owner.physics.GetVelocity().x);
        owner.animator.SetFloat("Direction", owner.physics.GetVelocity().z);
    }

    public Vector3 GetDirection()
    {
        return direction;
    }
}
