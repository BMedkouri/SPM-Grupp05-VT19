using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 cameraRotation;
    private SphereCollider sphereCollider;
    private RaycastHit hitInfo;
    Vector3 cameraMovement;

    [SerializeField] private Vector3 cameraOffset;      // 1.2, 1.5, -4
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float minimumXRotation;
    [SerializeField] private float maximumXRotation;
    [SerializeField] private LayerMask geometryLayer;

    private void Awake()
    {
        cameraRotation = Vector2.zero;
        sphereCollider = GetComponent<SphereCollider>();
        cameraMovement = Vector3.zero;
    }

    private void Update()
    {
        //Moves camera
        CameraMovement();
    }

    private void CameraMovement()
    {
        //Receives input from mouse, multiplied by mouseSensitivity
        cameraRotation.x -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        cameraRotation.y += Input.GetAxisRaw("Mouse X") * mouseSensitivity;

        //Sets a min and max for rotation on the x-axis. Basically how far up or down the character can look
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, minimumXRotation, maximumXRotation);

        //Adjusts the camera in accordance with the camera offset
        cameraMovement = Quaternion.Euler(cameraRotation) * cameraOffset;

        //Rotates camera based on input
        transform.rotation = Quaternion.Euler(cameraRotation);

        //Checks for collisions
        CameraCollisionCheck();

        //Transforms the camera based on input and collision check
        transform.position = cameraMovement + transform.parent.position;
    }

    private void CameraCollisionCheck()
    {
        int escape = 100;
        do
        {
            if (Physics.SphereCast(transform.parent.position, sphereCollider.radius, cameraMovement.normalized, out hitInfo, cameraMovement.magnitude + sphereCollider.radius, geometryLayer))
            {
                if (hitInfo.distance - sphereCollider.radius > sphereCollider.radius)
                {
                    cameraMovement = cameraMovement.normalized * (hitInfo.distance - sphereCollider.radius);
                }
                else
                {
                    cameraMovement = cameraMovement.normalized * (-sphereCollider.radius);
                }
            }
            escape--;
        } while (hitInfo.collider != null && escape > 0);
    }

    public void SetCameraOffset(Vector3 newCameraOffset)
    {
        cameraOffset = newCameraOffset;
    }

    public Vector3 GetCameraOffset()
    {
        return cameraOffset;
    }
}
