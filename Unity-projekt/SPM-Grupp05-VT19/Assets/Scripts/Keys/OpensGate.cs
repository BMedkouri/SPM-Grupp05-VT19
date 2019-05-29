//Author: Bilal El Medkouri

using UnityEngine;

public class OpensGate : MonoBehaviour
{
    private void OnDestroy()
    {
        Gate.Instance.OpenTheGates();

        SaveGameEvent saveGameEvent = new SaveGameEvent(Player.PlayerReference.transform.position);
        saveGameEvent.FireEvent();
    }
}
