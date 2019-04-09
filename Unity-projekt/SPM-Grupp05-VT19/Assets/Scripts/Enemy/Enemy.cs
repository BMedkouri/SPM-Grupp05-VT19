using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    [HideInInspector] public MeshRenderer Renderer;
    private float playerDistance;
    public GameObject player;
    public LayerMask visionBlock;
    // Start is called before the first frame update
    protected override void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        base.Awake();
        visionBlock = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
    }
    public float getDistance()
    {
        return playerDistance;
    }
}
