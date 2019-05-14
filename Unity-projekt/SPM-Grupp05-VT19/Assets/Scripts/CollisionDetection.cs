//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
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

        //Moves target and resets snaps per frame
        transform.position += physics.GetVelocity() * Time.deltaTime - sumOfSnapsPerFrame;
        sumOfSnapsPerFrame = Vector3.zero;
    }

    private void CollisionCheck()
    {
        int escape = 10;
        do
        {
            Vector3 normalForce = Vector3.zero;
            if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, physics.GetVelocity().normalized, out hitInfo, Mathf.Infinity, rayCastLayerMask))
            {
                float angleOfImpact = Functions.CalculateAngleOfImpact(physics.GetVelocity(), hitInfo.normal);
                float hypotenuse = Functions.CalculateHypotenuse(angleOfImpact, skinWidth);

                float temporarySkinWidth = (skinWidth > hypotenuse ? skinWidth : hypotenuse);

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
                    normalForce = Functions.CalculateNormalForce(physics.GetVelocity(), hitInfo.normal);

                    if (normalForce == -physics.GetVelocity() || normalForce == Vector3.zero)
                    {
                        escape = 0;
                    }

                    physics.ApplyForces(normalForce);
                }
            }
            escape--;
        } while (hitInfo.collider != null && escape > 0);
    }

    public bool IsGrounded()
    {
        RaycastHit hitInfo = new RaycastHit();

        return Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, temporarySkinWidth + groundCheckDistance, rayCastLayerMask);
    }

    public RaycastHit GetGroundRaycastHit()
    {
        RaycastHit hitInfo = new RaycastHit();

        Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, rayCastLayerMask);
        
        return hitInfo;
    }
}
