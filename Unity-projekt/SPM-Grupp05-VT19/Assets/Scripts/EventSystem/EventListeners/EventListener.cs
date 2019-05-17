//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

public abstract class EventListener<T> : MonoBehaviour where T : Event<T>
{
    protected virtual void Start()
    {
        Event<T>.RegisterListener(OnEvent);
    }

    protected virtual void OnDestroy()
    {
        Event<T>.UnregisterListener(OnEvent);
    }

    protected virtual void OnEvent(T eventType) { }
}