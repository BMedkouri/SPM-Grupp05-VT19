using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator anim;

    public float speed;
    public float direction;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        speed = Input.GetAxis("Vertical");
        direction = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", speed);
        anim.SetFloat("Direction", direction);

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Dodge");
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Slash");
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("LightAttack");
        }

    }
}
