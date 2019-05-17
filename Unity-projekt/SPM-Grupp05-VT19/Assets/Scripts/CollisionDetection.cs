//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private PhysicsComponent physics;
    private RaycastHit hitInfo;
    private Vector3 sumOfSnapsPerFrame;

    private CapsuleCollider capsuleCollider;
    private Vector3 point1;
    private Vector3 point2;

    [SerializeField] private float skinWidth;               // 0.065f
    [SerializeField] private float groundCheckDistance;     // 0.1f
    [SerializeField] private LayerMask rayCastLayerMask;
    private float temporarySkinWidth;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        physics = GetComponent<PhysicsComponent>();
        sumOfSnapsPerFrame = new Vector3();

        capsuleCollider = GetComponent<CapsuleCollider>();

        point1 = capsuleCollider.center + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        point2 = capsuleCollider.center + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);
    }

    private void FixedUpdate()
    {
        CollisionCheck();

        // Moves target and resets snaps per frame
        transform.position += physics.Velocity * Time.deltaTime - sumOfSnapsPerFrame;
        sumOfSnapsPerFrame = Vector3.zero;
    }

    private void CollisionCheck()
    {
        int escape = 10;
        do
        {
            Vector3 normalForce = Vector3.zero;
            if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, physics.Velocity.normalized, out hitInfo, Mathf.Infinity, rayCastLayerMask))
            {
                float angleOfImpact = Functions.CalculateAngleOfImpact(physics.Velocity, hitInfo.normal);
                float hypotenuse = Functions.CalculateHypotenuse(angleOfImpact, skinWidth);

                float temporarySkinWidth = (skinWidth > hypotenuse ? skinWidth : hypotenuse);

                if (hitInfo.distance - temporarySkinWidth <= physics.Velocity.magnitude * Time.deltaTime + temporarySkinWidth)
                {
                    if (hitInfo.distance - temporarySkinWidth > temporarySkinWidth)
                    {
                        sumOfSnapsPerFrame += physics.Velocity.normalized * (hitInfo.distance - temporarySkinWidth);
                        transform.position += physics.Velocity.normalized * (hitInfo.distance - temporarySkinWidth);
                    }
                    else
                    {
                        sumOfSnapsPerFrame -= physics.Velocity.normalized * (temporarySkinWidth - hitInfo.distance);
                        transform.position -= physics.Velocity.normalized * (temporarySkinWidth - hitInfo.distance);
                    }
                    // Calculate and apply forces
                    normalForce = Functions.CalculateNormalForce(physics.Velocity, hitInfo.normal);

                    if (normalForce == -physics.Velocity || normalForce == Vector3.zero)
                    {
                        escape = 0;
                    }

                    CheckIfGrounded(normalForce);

                    physics.ApplyForces(normalForce);
                }
            }
            escape--;
        } while (hitInfo.collider != null && escape > 0);
    }

    private void CheckIfGrounded(Vector3 normalForce)
    {
        if (normalForce.y == -physics.Velocity.y)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    public RaycastHit GetGroundRaycastHit()
    {
        RaycastHit hitInfo = new RaycastHit();

        Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, rayCastLayerMask);

        return hitInfo;
    }
}
