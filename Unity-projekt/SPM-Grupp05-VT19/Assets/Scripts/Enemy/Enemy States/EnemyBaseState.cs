using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : State
{
    [SerializeField] protected float turnSpeedModifier;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Material material;

    protected Enemy owner;

    public override void Enter()
    {
        owner.Renderer.material = material;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (Enemy)owner;
    }
}
