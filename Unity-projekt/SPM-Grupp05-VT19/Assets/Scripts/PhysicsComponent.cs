using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Bilal El Medkouri
 * @co-author Anders Ragnar
 * 
 * This class applies physics on the object it's applied to.
 */

public class PhysicsComponent : MonoBehaviour
{
    [SerializeField] private float gravity; // 9.8f
    [SerializeField] private float staticFrictionCoefficient; // 0.8f
    [SerializeField] private float dynamicFrictionCoefficient; // 0.6f
    [SerializeField] private float airResistanceCoefficient; // 0.1f

    private Vector3 velocity;
    private Vector3 direction;
    
    /// <summary>
    /// This sets all our vectors to zero, it's a failsafe for us.
    /// </summary>
    private void Awake()
    {
        velocity = Vector3.zero;
    }

    /// <summary>
    /// Updates the gravity and airresistance on all the objects it's applied to.
    /// </summary>
    private void FixedUpdate()
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
    
    /// <summary>
    /// Change friction to work on movable objects, instead of current movingPlatform fix
    /// </summary>
    private void ApplyFriction(Vector3 normalForce)
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
    /// <summary>
    /// This Accelerates the object in any direction
    /// </summary>
    /// <param name="direction"></param>
    /// This is the direction the object should accelerate in.
    /// 
    /// <param name="acceleration"></param>
    /// What speed the player accelerats in.
    public void Accelerate(Vector3 direction, float acceleration)
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

    /// <summary>
    /// This is a method that is saved from the first assignment. 
    /// </summary>
    /// <param name="deceleration"></param>
    /// What speed the object should decelerate in.
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

    /// <summary>
    /// This makes the object jump.
    /// </summary>
    /// <param name="jumpHeight"></param>
    /// Is the hight the objects are going to jump.
    public void Jump(float jumpHeight)
    {
        velocity += Vector3.up * jumpHeight;
    }

    /// <summary>
    /// Applies normalforce to the object
    /// </summary>
    /// <param name="normal"></param>
    /// 
    public void ApplyForces(Vector3 normalForce)
    {
        //Apply normal force to velocity
        velocity += normalForce;

        //Apply friction
        ApplyFriction(normalForce);
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
