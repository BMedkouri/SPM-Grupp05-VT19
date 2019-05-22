//Author: Bilal El Medkouri


public class DamageEventListener : EventListener<DamageEvent>
{
    protected override void OnEvent(DamageEvent damageEvent)
    {
        damageEvent.DamagedGameObject.GetComponent<HealthComponent>().CurrentHealth -= damageEvent.Damage;

        DebugEvent debugEvent = new DebugEvent(damageEvent.InstigatorGameObject.name + " has dealt " + damageEvent.Damage + " to " + damageEvent.DamagedGameObject.name);
        debugEvent.FireEvent();

        // TODO: FIX! 
        //SoundEvent soundEvent = new SoundEvent(damageEvent.DamagedGameObject.transform.position, damageEvent.DamagedSoundEffect);
        //soundEvent.FireEvent();
    }
}
