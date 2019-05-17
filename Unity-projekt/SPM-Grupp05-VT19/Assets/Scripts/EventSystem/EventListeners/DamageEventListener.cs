//Author: Bilal El Medkouri


public class DamageEventListener : EventListener<DamageEvent>
{
    protected override void OnEvent(DamageEvent damageEvent)
    {
        DebugEvent currentHealthDebug = new DebugEvent("Current health: " + damageEvent.DamagedGameObject.GetComponent<HealthComponent>().CurrentHealth);
        currentHealthDebug.FireEvent();

        DebugEvent damage = new DebugEvent("Current health: " + (damageEvent.DamagedGameObject.GetComponent<HealthComponent>().CurrentHealth - damageEvent.Damage));
        damage.FireEvent();

        damageEvent.DamagedGameObject.GetComponent<HealthComponent>().CurrentHealth -= damageEvent.Damage;

        DebugEvent healthAfter = new DebugEvent("Current health: " + (damageEvent.DamagedGameObject.GetComponent<HealthComponent>().CurrentHealth));
        healthAfter.FireEvent();

        DebugEvent debugEvent = new DebugEvent(damageEvent.InstigatorGameObject.name + " has dealt " + damageEvent.Damage + " to " + damageEvent.DamagedGameObject.name);
        debugEvent.FireEvent();

        // TODO: FIX! 
        //SoundEvent soundEvent = new SoundEvent(damageEvent.DamagedGameObject.transform.position, damageEvent.DamagedSoundEffect);
        //soundEvent.FireEvent();
    }
}
