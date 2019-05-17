//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDodgeState")]
public class PlayerDodgeState : PlayerOnGroundState
{
    // Attributes

    [Header("Dodge properties:")]
    [SerializeField] private float dodgeTimer; // TODO: Replace this with animation length
    [SerializeField] private float dodgeSpeed;

    [Header("Stamina cost:")]
    [SerializeField] private float staminaExpenditure;

    private float countDown;

    /// <summary>
    /// Adds Velocity in the direction of the Joystick to make it feel like a dodge.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        if (owner.CurrentStamina < staminaExpenditure)
        {
            owner.Transition<PlayerOnGroundState>();
        }
        else
        {
            owner.CurrentStamina -= staminaExpenditure;

            owner.Physics.Velocity += (dodgeSpeed * owner.Physics.Direction);
            owner.Animator.SetTrigger("Dodge");

            countDown = dodgeTimer;
        }
    }

    public override void HandleUpdate()
    {
        if (countDown <= 0)
        {
            owner.Transition<PlayerOnGroundState>();
        }

        countDown -= Time.deltaTime;
    }
}
