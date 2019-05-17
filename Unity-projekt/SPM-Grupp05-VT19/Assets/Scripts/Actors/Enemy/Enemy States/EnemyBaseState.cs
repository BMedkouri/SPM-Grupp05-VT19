//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

public class EnemyBaseState : State
{
    [Header("Movement Speed:")]
    [SerializeField] protected float movementSpeed;

    [Header("Material:")]
    [SerializeField] protected Material material;

    protected Enemy owner;

    /// <summary>
    /// Sets the speed and the material.
    /// </summary>
    public override void Enter()
    {
        owner.Renderer.material = material;
        owner.Agent.speed = movementSpeed;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (Enemy)owner;
    }
}
