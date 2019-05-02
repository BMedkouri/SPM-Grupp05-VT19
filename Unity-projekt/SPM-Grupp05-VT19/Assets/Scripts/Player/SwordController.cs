using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Vector2 swordRotation;
    Vector3 swordMovement;

    [SerializeField] private Vector3 swordOffset;      // 0.56, 0.315, 0.1
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float minimumXRotation;
    [SerializeField] private float maximumXRotation;

    private void Awake()
    {
        swordRotation = Vector2.zero;
        swordMovement = Vector3.zero;
    }

    private void Update()
    {
        //Moves sword
        SwordMovement();
    }

    private void SwordMovement()
    {
        //Receives input from mouse, multiplied by mouseSensitivity
        swordRotation.x -= Input.GetAxis("Horizontal Turn") * mouseSensitivity;
        swordRotation.y += Input.GetAxis("Vertical Turn") * mouseSensitivity;

        //Sets a min and max for rotation on the x-axis. Basically how far up or down the character can look
        swordRotation.x = Mathf.Clamp(swordRotation.x, minimumXRotation, maximumXRotation);

        //Adjusts the sword in accordance with the sword offset
        swordMovement = Quaternion.Euler(swordRotation) * swordOffset;

        //Rotates sword based on input
        transform.rotation = Quaternion.Euler(swordRotation);

        //Transforms the sword based on input
        transform.position = swordMovement + transform.parent.position;
    }
}
