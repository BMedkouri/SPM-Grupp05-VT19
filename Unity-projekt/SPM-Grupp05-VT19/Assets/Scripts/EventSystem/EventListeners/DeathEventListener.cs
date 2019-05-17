//Author: Bilal El Medkouri


public class DeathEventListener : EventListener<DeathEvent>
{
    protected override void OnEvent(DeathEvent deathEvent)
    {
        DebugEvent debugEvent = new DebugEvent(deathEvent.DyingGameObject.name + " has died.");
        debugEvent.FireEvent();

        //SoundEvent soundEvent = new SoundEvent(deathEvent.DyingGameObject.transform.position, deathEvent.DeathSound);
        //soundEvent.FireEvent();

        //ParticleEvent particleEvent = new ParticleEvent(deathEvent.DyingGameObject.transform.position, deathEvent.DeathParticle);
        //particleEvent.FireEvent();

        Destroy(deathEvent.DyingGameObject);
    }
}