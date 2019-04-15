using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetection : MonoBehaviour
{
    private Collider collider;
    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;

    private RaycastHit hitInfo;

    private Vector3 currentPosition, oldPosition, distance, direction;

    [SerializeField] private float skinWidth;       // 0.063f
    [SerializeField] private LayerMask rayCastLayerMask;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        
        if (collider.GetType() == typeof(BoxCollider))
        {
            boxCollider = (BoxCollider)collider;
        }
        else if (collider.GetType() == typeof(SphereCollider))
        {
            sphereCollider = (SphereCollider)collider;
        }
    }

    public void RunCollisionDetection()
    {
        currentPosition = transform.position;

        if (collider.GetType() == typeof(BoxCollider))
        {
            CollisionCheck(boxCollider);
        }
        else if (collider.GetType() == typeof(SphereCollider))
        {
            CollisionCheck(sphereCollider);
        }

        oldPosition = currentPosition;
    }

    private void CollisionCheck(BoxCollider boxCollider)
    {
        SetDistanceAndDirection();

        Physics.BoxCast(transform.position, Vector3.Scale((boxCollider.size * 0.5f), transform.localScale), direction, out hitInfo, transform.localRotation, distance.magnitude + skinWidth, rayCastLayerMask);
    }
    private void CollisionCheck(SphereCollider sphereCollider)
    {
        SetDistanceAndDirection();
        Physics.SphereCast(transform.position, sphereCollider.radius, direction, out hitInfo, distance.magnitude + skinWidth, rayCastLayerMask);
        Debug.DrawRay(transform.position, direction, Color.red);
        Debug.Log(direction);
    }

    private void SetDistanceAndDirection()
    {
        distance = currentPosition - oldPosition;
        direction = distance.normalized;
    }

    public RaycastHit GetHitInfo()
    {
        return hitInfo;
    }

    public Enemy GetEnemy()
    {
        return hitInfo.transform.GetComponent<Enemy>();
    }

    public void InitializeOldPosition()
    {
        oldPosition = transform.position;
    }
}
