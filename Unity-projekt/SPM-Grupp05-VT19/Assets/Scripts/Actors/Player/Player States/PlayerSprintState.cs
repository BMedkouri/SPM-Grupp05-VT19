//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerSprintState")]
public class PlayerSprintState : PlayerRunState
{
    // Attributes
    [SerializeField] private float staminaExpenditure;  // Stamina cost per second

    // Methods
    public override void Enter()
    {
        base.Enter();

        if (owner.CurrentStamina < staminaExpenditure * Time.deltaTime)
        {
            owner.Transition<PlayerRunState>();
        }
    }

    public override void HandleUpdate()
    {
        if (Input.GetButton("Xbox X") && GetDirection() != Vector3.zero)
        {
            owner.CurrentStamina -= staminaExpenditure * Time.deltaTime;

            if (owner.CurrentStamina < staminaExpenditure * Time.deltaTime)
            {
                owner.Transition<PlayerRunState>();
            }
        }
        else
        {
            owner.Transition<PlayerRunState>();
        }
        base.HandleUpdate();
    }
}
