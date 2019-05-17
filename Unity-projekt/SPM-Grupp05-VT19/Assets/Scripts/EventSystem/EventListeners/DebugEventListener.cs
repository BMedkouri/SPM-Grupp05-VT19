//Author: Bilal El Medkouri

using UnityEngine;

public class DebugEventListener : EventListener<DebugEvent>
{
    protected override void OnEvent(DebugEvent debugEvent)
    {
        Debug.Log(debugEvent.DebugMessage);
    }
}
