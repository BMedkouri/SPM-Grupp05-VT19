//Author: Bilal El Medkouri

using UnityEngine;

public class MovementInput : MonoBehaviour
{
    [SerializeField] private float inputX;
    [SerializeField] private float inputZ;
    [SerializeField] private Vector3 desiredMoveDirection;
    [SerializeField] private bool blockRotationPlayer;
    [SerializeField] private float desiredRotationSpeed;
    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float allowPlayerRotation;
    private Camera mainCamera;
    private CharacterController controller;
    public bool IsGrounded { get; private set; }
    private float verticalVelocity;
    private Vector3 moveVector;

    public Vector3 DesiredMoveDirection { get => desiredMoveDirection; set => desiredMoveDirection = value; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    public void UpdateMovementInput()
    {
        InputMagnitude();

        IsGrounded = controller.isGrounded;
        if (IsGrounded)
        {
            verticalVelocity -= 0f;
        }
        else
        {
            verticalVelocity -= 2f;
        }

        moveVector = new Vector3(0f, verticalVelocity, 0f);
        controller.Move(moveVector);
    }

    private void PlayerMoveAndRotation()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        Camera camera = Camera.main;
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        DesiredMoveDirection = forward * inputZ + right * inputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesiredMoveDirection), desiredRotationSpeed);
        }
    }

    private void InputMagnitude()
    {
        // Calculate Input Vectors
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        animator.SetFloat("InputZ", inputZ, 0f, Time.deltaTime * 2f);
        animator.SetFloat("InputX", inputX, 0f, Time.deltaTime * 2f);

        // Calculate the Input Magnitude
        speed = new Vector2(inputX, inputZ).sqrMagnitude;

        // Physically move player
        if (speed > allowPlayerRotation)
        {
            animator.SetFloat("InputMagnitude", speed, 0f, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (speed < allowPlayerRotation)
        {
            animator.SetFloat("InputMagnitude", speed, 0f, Time.deltaTime);
        }
    }
}
