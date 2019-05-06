using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private PhysicsComponent physics;
    private Collider collider;
    private RaycastHit hitInfo;
    private Vector3 sumOfSnapsPerFrame;

    private CapsuleCollider capsuleCollider;
    private Vector3 point1;
    private Vector3 point2;

    private SphereCollider sphereCollider;

    [SerializeField] private float skinWidth;               // 0.063f
    [SerializeField] private float groundCheckDistance;     // 0.063f
    [SerializeField] private LayerMask rayCastLayerMask;
    float temporarySkinWidth;

    private void Awake()
    {
        physics = GetComponent<PhysicsComponent>();
        collider = GetComponent<Collider>();
        sumOfSnapsPerFrame = new Vector3();

        if (collider.GetType() == typeof(CapsuleCollider))
        {
            capsuleCollider = (CapsuleCollider)collider;

            point1 = capsuleCollider.center + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
            point2 = capsuleCollider.center + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);
        }

        if (collider.GetType() == typeof(SphereCollider))
        {
            sphereCollider = (SphereCollider)collider;
        }
    }

    private void Update()
    {
        if (collider.GetType() == typeof(CapsuleCollider))
        {
            CollisionCheck(capsuleCollider);
        }

        //Moves target and resets snaps per frame
        transform.position += physics.GetVelocity() * Time.deltaTime - sumOfSnapsPerFrame;
        sumOfSnapsPerFrame = Vector3.zero;
    }

    private void CollisionCheck(CapsuleCollider capsuleCollider)
    {
        int escape = 100;
        do
        {
            if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, physics.GetVelocity().normalized, out hitInfo, Mathf.Infinity, rayCastLayerMask))
            {
                float angleOfImpact = Functions.CalculateAngleOfImpact(physics.GetVelocity(), hitInfo.normal);
                float hypotenuse = Functions.CalculateHypotenuse(angleOfImpact, skinWidth);

                temporarySkinWidth = (skinWidth > hypotenuse ? skinWidth : hypotenuse);

                if (hitInfo.distance - temporarySkinWidth <= physics.GetVelocity().magnitude * Time.deltaTime + temporarySkinWidth)
                {
                    if (hitInfo.distance - temporarySkinWidth > temporarySkinWidth)
                    {
                        sumOfSnapsPerFrame += physics.GetVelocity().normalized * (hitInfo.distance - temporarySkinWidth);
                        transform.position += physics.GetVelocity().normalized * (hitInfo.distance - temporarySkinWidth);
                    }
                    else
                    {
                        sumOfSnapsPerFrame -= physics.GetVelocity().normalized * (temporarySkinWidth - hitInfo.distance);
                        transform.position -= physics.GetVelocity().normalized * (temporarySkinWidth - hitInfo.distance);
                    }
                    // Calculate and apply forces
                    physics.CalculateAndApplyForces(hitInfo.normal);
                }
            }
            escape--;
        } while (hitInfo.collider != null && escape > 0);
    }

    public bool IsGrounded()
    {
        RaycastHit hitInfo = new RaycastHit();

        if (collider.GetType() == typeof(CapsuleCollider))
        {
            return Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, temporarySkinWidth + groundCheckDistance, rayCastLayerMask);
        }
        else if (collider.GetType() == typeof(SphereCollider))
        {
            return Physics.SphereCast(transform.position + sphereCollider.center, capsuleCollider.radius, Vector3.down, out hitInfo, temporarySkinWidth + groundCheckDistance, rayCastLayerMask);
        }
        
        Debug.Log("Is not grounded.");
        return false;
    }

    public RaycastHit GetGroundRaycastHit()
    {
        RaycastHit hitInfo = new RaycastHit();

        if (collider.GetType() == typeof(CapsuleCollider))
        {
            Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, rayCastLayerMask);
        }
        else if (collider.GetType() == typeof(SphereCollider))
        {
            Physics.SphereCast(transform.position + sphereCollider.center, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, rayCastLayerMask);
        }

        return hitInfo;
    }
}
