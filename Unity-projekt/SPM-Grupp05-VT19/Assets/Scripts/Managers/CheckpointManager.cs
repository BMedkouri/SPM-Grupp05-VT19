//Author: Bilal El Medkouri

using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    [Header("Checkpoints")]
    [SerializeField] private GameObject[] checkpoints;

    private void Awake()
    {
        Debug.Log("CM Awake");

        Instance = this;

        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].GetComponent<Checkpoint>().ID = i;
        }
    }

    public Vector3 GetCheckpointPosition(int ID)
    {
        return checkpoints[ID].GetComponent<Checkpoint>().RespawnPosition;
    }
}
