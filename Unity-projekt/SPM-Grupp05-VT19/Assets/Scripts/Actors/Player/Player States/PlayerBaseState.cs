using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    // Attributes
    //[SerializeField] protected float jumpHeight;              // 7f
    //[SerializeField] protected float acceleration;            // 14f
    //[SerializeField] protected float turnSpeedModifier;       // 5f
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
       // owner.renderer.material = material;
    }

    public override void HandleUpdate()
    {
        //Handles input
        PlayerInput();

        //Regeneration
        owner.Regeneration();
    }

    private void PlayerInput()
    {
        //Takes input from player
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //owner.animator.SetFloat("Speed", Input.GetAxis("Horizontal"));
        //owner.animator.SetFloat("Direction", Input.GetAxis("Vertical"));
        Vector3 input = direction;
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
        if (Input.GetAxisRaw("Left Trigger") == 1 && !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") && !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") && !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<PlayerParryState>();
        }
        if(Input.GetButtonDown("Left Bumper") && !owner.GetCurrentState().ToString().Equals("AttackState(Clone) (AttackState)") && !owner.GetCurrentState().ToString().Equals("PlayerParryState(Clone) (PlayerParryState)") && !owner.GetCurrentState().ToString().Equals("PlayerLightState(Clone) (PlayerLightState)"))
        {
            owner.Transition<PlayerLightState>();
        }
        //Movement
        if (direction != Vector3.zero)
        {
            owner.physics.Accelerate(direction, owner.Acceleration);
            
            
            //owner.collision.CollisionCheck(direction * input.magnitude * owner.Acceleration * Time.deltaTime);
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
