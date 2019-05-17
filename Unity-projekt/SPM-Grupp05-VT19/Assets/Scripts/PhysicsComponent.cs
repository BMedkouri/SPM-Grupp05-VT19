//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;


public class PhysicsComponent : MonoBehaviour
{
    // Attributes

    [Range(9f, 10f)]
    [SerializeField] private float gravity;

    [Range(0.6f, 1f)]
    [SerializeField] private float staticFrictionCoefficient;
    private float staticFriction;

    [Range(0.3f, 0.6f)]
    [SerializeField] private float dynamicFrictionCoefficient;
    private float dynamicFriction;

    [Range(0.05f, 0.5f)]
    [SerializeField] private float airResistanceCoefficient;

    public Vector3 Velocity { get; set; }
    public Vector3 Direction { get; set; }


    // Methods
    private void Awake()
    {
        Velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyAirResistance();
    }

    private void ApplyGravity()
    {
        Velocity += Vector3.down * gravity * Time.deltaTime;
    }

    private void ApplyAirResistance()
    {
        Velocity *= Mathf.Pow(airResistanceCoefficient, Time.deltaTime);
    }

    private void ApplyFriction(Vector3 normalForce)
    {
        staticFriction = Functions.CalculateFriction(staticFrictionCoefficient, normalForce);
        dynamicFriction = Functions.CalculateFriction(dynamicFrictionCoefficient, normalForce);

        if (Velocity.magnitude < staticFriction)
        {
            Velocity = Vector3.zero;
        }
        else
        {
            Velocity += -Velocity.normalized * dynamicFriction;
        }
    }

    public void Accelerate(Vector3 direction, float acceleration)
    {
        Direction = direction;
        if (direction.magnitude > 1)
        {
            Velocity += acceleration * direction.normalized * Time.deltaTime;
        }
        else
        {
            Velocity += acceleration * direction * Time.deltaTime;
        }
    }

    public void ApplyForces(Vector3 normalForce)
    {
        //Apply normal force to velocity
        Velocity += normalForce;

        //Apply friction
        ApplyFriction(normalForce);
    }
}
