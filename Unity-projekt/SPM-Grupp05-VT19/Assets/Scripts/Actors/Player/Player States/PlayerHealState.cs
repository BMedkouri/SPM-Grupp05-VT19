//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerHealState")]
public class PlayerHealState : PlayerBaseState
{
    [Header("Heal properties:")]
    [SerializeField] private float healCastDuration, healAmount;
    private float timer;

    //Methods
    public override void Enter()
    {
        owner.Animator.SetTrigger("Heal");
        //base.Enter();
        //timer = healCastDuration;
    }

    public override void HandleUpdate()
    {
        //if (timer <= 0)
        //{
        //    owner.GetComponent<HealthComponent>().CurrentHealth += healAmount;
        //    owner.Transition<PlayerOnGroundState>();
        //}
        //timer -= Time.deltaTime;
    }
}
