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
    private CapsuleCollider capsuleCollider;
    private Vector3 point1, point2;

    // Methods
    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
        capsuleCollider = owner.GetComponent<CapsuleCollider>();
        point1 = capsuleCollider.center + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        point2 = capsuleCollider.center + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);
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
    }

    private void PlayerInput()
    {
        //Takes input from player
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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
            owner.physics.Accelerate(direction, owner.Acceleration, 0);
            //Vector3 movementSpeed = direction * input.magnitude * owner.Acceleration;
            //owner.transform.position += LookForCollision(movementSpeed) * Time.deltaTime;
            //Rotates the players mesh with the direction
            owner.rotate.Rotate(direction);
        }

        //Take damage - For testing purposes
        if (Input.GetKeyDown(KeyCode.L))
        {
            owner.LoseStamina(20.0f);
            owner.LoseEnergy(10.0f);
        }

        //Heal player - For testing purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
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

    public Vector3 LookForCollision(Vector3 movementSpeed)
    {
        LayerMask layer = LayerMask.GetMask("Geometry");
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.CapsuleCast(owner.transform.position + point1, owner.transform.position + point2, capsuleCollider.radius, (direction * owner.Acceleration).normalized, out hitInfo, Mathf.Infinity, layer))
        {
            Debug.Log("Hit");
            if (hitInfo.distance < 0.1f)
            {
                movementSpeed = Vector3.zero;
                Debug.Log("Vector zero");
            }
        }
        return movementSpeed;
    }
}
