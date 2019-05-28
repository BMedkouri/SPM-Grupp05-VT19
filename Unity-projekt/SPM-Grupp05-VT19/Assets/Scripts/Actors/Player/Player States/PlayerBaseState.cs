//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

public class PlayerBaseState : State
{
    // Attributes
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
        if (owner.Collision.IsGrounded == true)
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, owner.Collision.GetGroundRaycastHit().normal).normalized;
        }
        else
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, Vector3.up).normalized;
        }
        //Movement
        if (direction != Vector3.zero)
        {
            owner.Physics.Accelerate(direction, owner.Acceleration);

            // If the grounds normals angle is equals to or less than 50 degrees, this projects the players velocity onto the ground plane
            if (Vector3.Angle(owner.Collision.GetGroundRaycastHit().normal, Vector3.up) <= 50)
            {
                owner.Physics.Velocity = (Vector3.ProjectOnPlane(owner.Physics.Velocity, owner.Collision.GetGroundRaycastHit().normal));
            }

            //Rotates the players mesh with the direction
            owner.RotatePlayer.Rotate(direction);
        }

        //Heal player - For testing purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
            owner.CurrentStamina += 15.0f;
            owner.CurrentEnergy += 10.0f;
        }

        // Temporary 
        if (Input.GetKeyDown(KeyCode.V))
        {
            owner.transform.position += Vector3.up * 5f;
        }

        if (Input.GetAxisRaw("Right Trigger") == 1 )
        {
            owner.Transition<PlayerAttackState>();
        }
        else if (Input.GetAxisRaw("Left Trigger") == 1)
        {
            owner.Transition<PlayerParryState>();
        }
        else if (Input.GetButtonDown("Left Bumper") )
        {
            owner.Transition<PlayerLightState>();
        }
        
        if (owner.Collision.IsGrounded == false)
        {
            owner.Transition<PlayerInAirState>();
        }

        owner.Animator.SetFloat("Speed", owner.Physics.Velocity.x);
        owner.Animator.SetFloat("Direction", owner.Physics.Velocity.z);
    }

    public Vector3 GetDirection()
    {
        return direction;
    }
}
