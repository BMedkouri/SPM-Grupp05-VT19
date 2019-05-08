using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Anders Ragnar
 * @co-author Bilal El Medkouri
 */
public class EnemyBaseState : State
{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Material material;

    protected Enemy owner;

    /// <summary>
    /// Sets the speed and the material.
    /// </summary>
    public override void Enter()
    {
        owner.renderer.material = material;
	    owner.agent.speed = movementSpeed;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (Enemy)owner;
    }
}
