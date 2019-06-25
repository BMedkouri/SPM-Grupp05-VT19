//Author: Bilal El Medkouri

using UnityEngine;

public class HitEventListener : EventListener<HitEvent>
{
    protected override void OnEvent(HitEvent hitEvent)
    {
        DebugEvent debugEvent = new DebugEvent("Hit!");

        Vector3 invertedHitTrajectory = Vector3.Scale(hitEvent.HitContactPoint.normal, hitEvent.HitContactPoint.point);

        // TODO: FIX!
        //ParticleEvent particleEvent = new ParticleEvent(invertedHitTrajectory, hitEvent.HitParticleEffect);
        //particleEvent.FireEvent();
    }
}
