//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventListener : MonoBehaviour
{
    private void Start()
    {
        DamageEvent.RegisterListener(OnDamageEvent);
    }

    private void OnDestroy()
    {
        DamageEvent.UnregisterListener(OnDamageEvent);
    }

    private void OnDamageEvent(DamageEvent damageEvent)
    {
        // If the actor taking damage is the player, update the UI accordingly.
        if(damageEvent.DamagedGameObject.layer == 9)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().RemoveHealth(damageEvent.Damage);
        }
        else if (damageEvent.DamagedGameObject.layer == 11)
        {
            damageEvent.DamagedGameObject.GetComponentInChildren<EnemyCanvasController>().RemoveHealth(damageEvent.Damage);
        }

        DebugEvent debugEvent = new DebugEvent
        {
            DebugMessage = damageEvent.DamagedGameObject.name + " has taken " + damageEvent.Damage + " damage."
        };
        debugEvent.FireEvent();

        SoundEvent soundEvent = new SoundEvent
        {
            AudioLocation = damageEvent.DamagedGameObject.transform.position,
            AudioSource = damageEvent.DamagedSoundEffect
        };
        soundEvent.FireEvent();

        ParticleEvent particleEvent = new ParticleEvent
        {
            ParticleLocation = damageEvent.DamagedGameObject.transform.position,
            ParticleSystem = damageEvent.DamagedParticleSystem
        };
        particleEvent.FireEvent();
    }
}
