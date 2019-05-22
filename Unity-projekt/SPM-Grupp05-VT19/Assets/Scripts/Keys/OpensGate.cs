//Author: Bilal El Medkouri

using UnityEngine;

public class OpensGate : MonoBehaviour
{
    private void OnDestroy()
    {
        Gate.Instance.OpenTheGates();
    }
}
