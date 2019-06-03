//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar


using UnityEngine;

/// <summary>
/// Script in charge of moving and rotating the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Vector2 startingRotation;

    [SerializeField] private float yAxisJoystickSensitivity, xAxisJoystickSensitivity;
    [SerializeField] private bool yAxisInverted, xAxisInverted;

    [SerializeField] private float minimumXRotation;
    [SerializeField] private float maximumXRotation;
    [SerializeField] private LayerMask geometryLayer;

    private Vector2 cameraRotation;
    private Vector3 cameraMovement;

    private SphereCollider sphereCollider;
    private RaycastHit hitInfo;



    /// <summary>
    /// Gets the spherecollider that makes sure that our camera doesn't pass through walls.
    /// Sets the camera's starting rotation.
    /// </summary>
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        startingRotation.y -= Player.PlayerReference.transform.rotation.y;

        cameraRotation = startingRotation;
    }

    /// <summary>
    /// Calls on our CameraMovement() script.
    /// </summary>
    private void LateUpdate()
    {
        //Moves camera
        CameraMovement();
    }

    /// <summary>
    /// Checks the options for inverted camera controls.
    /// Rotates the camera based on input, and whether or not axes have been inverted.
    /// Checks for collision via CameraCollisionCheck() and then moves the camera.
    /// </summary>
    private void CameraMovement()
    {
        int yAxisInvertion = yAxisInverted ? -1 : 1;
        int xAxisInvertion = xAxisInverted ? -1 : 1;


        //Receives input from mouse, multiplied by mouseSensitivity
        cameraRotation.x -= Input.GetAxis("Horizontal Turn") * yAxisJoystickSensitivity * xAxisInvertion;
        cameraRotation.y += Input.GetAxis("Vertical Turn") * xAxisJoystickSensitivity * yAxisInvertion;


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

    /// <summary>
    /// Works pretty similarly to our CollisionDetection script. 
    /// Checks for collision and moves the camera if a collision has been detected.
    /// </summary>
    private void CameraCollisionCheck()
    {
        int escape = 5;

        do
        {
            Vector3 sphereCastOriginPosition = new Vector3(transform.parent.position.x, transform.parent.position.y + cameraOffset.y, transform.parent.position.z);

            if (Physics.SphereCast(sphereCastOriginPosition, sphereCollider.radius, cameraMovement.normalized, out hitInfo, cameraMovement.magnitude + sphereCollider.radius, geometryLayer))
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
