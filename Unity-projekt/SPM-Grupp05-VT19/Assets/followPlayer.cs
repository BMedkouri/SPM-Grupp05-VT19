using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float speed = 2.0f;
    public float accuracy = 0.01f;
    public Transform goal;

    void Start()
    {
        this.transform.LookAt(goal.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y,
            goal.position.z);
        this.transform.LookAt(lookAtGoal);

        if (Vector3.Distance(transform.position, lookAtGoal) > accuracy)
            this.transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
