//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar


public class PlayerBaseState : State
{
    protected Player owner;

    #region Methods
    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
    }

    public override void HandleUpdate()
    {
        PlayerRegeneration(); // Stamina and energy only.
    }

    protected void PlayerRegeneration()
    {
        owner.Regeneration();
    }
    #endregion Methods
}
