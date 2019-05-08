//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEventListener : MonoBehaviour
{
    private void Start()
    {
        DebugEvent.RegisterListener(OnDebugEvent);
    }

    private void OnDestroy()
    {
        DebugEvent.UnregisterListener(OnDebugEvent);
    }

    private void OnDebugEvent(DebugEvent debugEvent)
    {
        Debug.Log(debugEvent.DebugMessage);
    }
}
