//Author: Bilal El Medkouri

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject respawnPosition;
    public Vector3 RespawnPosition { get => respawnPosition.transform.position; }

    public int ID { get; set; }

    private bool hasBeenTriggered;

    private void Awake()
    {
        hasBeenTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasBeenTriggered == false)
            {
                hasBeenTriggered = true;

                CheckpointEvent checkpointEvent = new CheckpointEvent(ID);
                checkpointEvent.FireEvent();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasBeenTriggered = false;
        }
    }
}
