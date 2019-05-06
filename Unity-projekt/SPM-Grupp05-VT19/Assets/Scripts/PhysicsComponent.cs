using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour
{
    [SerializeField] private float gravity; // 9.8f
    [SerializeField] private float staticFrictionCoefficient; // 0.5f
    [SerializeField] private float dynamicFrictionCoefficient; // 0.5f * 0.6f ( = 0.3f)
    [SerializeField] private float airResistanceCoefficient; // 0.5f

    [SerializeField] private Vector3 velocity, normalForce; //For testing
    private Vector3 direction;

    private void Awake()
    {
        velocity = Vector3.zero; normalForce = Vector3.zero;
    }

    private void Update()
    {
        ApplyGravity();
        ApplyAirResistance();
    }

    private void ApplyGravity()
    {
        //Apply gravity
        velocity += Vector3.down * gravity * Time.deltaTime;
    }

    private void ApplyAirResistance()
    {
        //airResistanceCoefficient = Functions.CalculateAirResistanceCoefficient(maxSpeed, velocity);

        //Apply air resistance
        velocity *= Mathf.Pow(airResistanceCoefficient, Time.deltaTime);
    }

    //Change friction to work on movable objects, instead of current movingPlatform fix
    private void ApplyFriction()
    {
        float staticFriction = Functions.CalculateFriction(staticFrictionCoefficient, normalForce);
        float dynamicFriction = Functions.CalculateFriction(dynamicFrictionCoefficient, normalForce);

        if (velocity.magnitude < staticFriction)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity += -velocity.normalized * dynamicFriction;
        }
    }

    public void Move(Vector3 direction, float speed)
    {
        this.direction = direction;
        velocity = speed * direction * Time.deltaTime;
    }

    public void Accelerate(Vector3 direction, float acceleration, float turnSpeedModifier)
    {
        this.direction = direction;
        if (direction.magnitude > 1)
        {
            velocity += acceleration * direction.normalized * Time.deltaTime;
        }
        else
        {
            velocity += acceleration * direction * Time.deltaTime;
        }
    }

    public void Decelerate(float deceleration)
    {
        if (Mathf.Abs(velocity.x) < deceleration * Time.deltaTime)
        {
            velocity.x = 0;
        }
        else
        {
            Vector3 currentVelocity = new Vector3(velocity.x, 0);
            velocity -= currentVelocity.normalized * deceleration * Time.deltaTime;
        }
    }

    public void Jump(float jumpHeight)
    {
        velocity += Vector3.up * jumpHeight;
    }

    public void CalculateAndApplyForces(Vector3 normal)
    {
        //Calculate normal force
        normalForce = Functions.CalculateNormalForce(velocity, normal);

        //Apply normal force to velocity
        velocity += normalForce;

        //Apply friction
        ApplyFriction();
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void AddVelocity(Vector3 velocity)
    {
        this.velocity += velocity;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }
}
