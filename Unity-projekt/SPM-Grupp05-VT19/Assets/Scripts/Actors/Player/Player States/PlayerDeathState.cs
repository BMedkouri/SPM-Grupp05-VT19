//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

[CreateAssetMenu(menuName = "Player States/PlayerDeathState")]
public class PlayerDeathState : PlayerBaseState
{
    // Methods
    public override void Enter()
    {
        owner.GetComponent<Renderer>().enabled = false;
    }

    public override void HandleUpdate() { }
}
