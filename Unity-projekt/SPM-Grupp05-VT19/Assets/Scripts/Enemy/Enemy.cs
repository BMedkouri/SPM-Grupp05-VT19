using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    [HideInInspector] public MeshRenderer Renderer;

    public GameObject player;
    public LayerMask visionBlock;
    // Start is called before the first frame update
    protected override void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base.Awake();
        visionBlock = LayerMask.GetMask("Ground");
    }
}
