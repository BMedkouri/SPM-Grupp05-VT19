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
            if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, physics.GetVelocity().normalized, out hitInfo, physics.GetVelocity().magnitude * Time.deltaTime + skinWidth, rayCastLayerMask))
            {
                if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, -hitInfo.normal, out hitInfo, physics.GetVelocity().magnitude * Time.deltaTime + skinWidth, rayCastLayerMask))
                {
                    if (hitInfo.distance - skinWidth > skinWidth)
                    {
                        sumOfSnapsPerFrame += -hitInfo.normal * (hitInfo.distance - skinWidth);
                        transform.position += -hitInfo.normal * (hitInfo.distance - skinWidth);
                    }
                    else
                    {
                        sumOfSnapsPerFrame += -hitInfo.normal * (-skinWidth);
                        transform.position += -hitInfo.normal * (-skinWidth);
                    }
                    //Calculate and apply forces
                    physics.CalculateAndApplyForces(hitInfo.normal);
                }
            }
            escape--;
        } while (hitInfo.collider != null && escape > 0);
    }
}
