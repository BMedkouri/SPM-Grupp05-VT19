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

    // Update is called once per frame
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

    }
}
