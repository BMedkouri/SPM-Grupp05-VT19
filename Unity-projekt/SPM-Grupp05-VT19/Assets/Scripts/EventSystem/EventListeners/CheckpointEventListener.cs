//Author: Bilal El Medkouri

using UnityEngine;

public class CheckpointEventListener : EventListener<CheckpointEvent>
{
    protected override void OnEvent(CheckpointEvent checkpointEvent)
    {
        DebugEvent debugEvent = new DebugEvent("Checkpoint " + checkpointEvent.CheckpointNumber + " reached.");
        debugEvent.FireEvent();

        Vector3 savePosition = CheckpointManager.Instance.GetCheckpointPosition(checkpointEvent.CheckpointNumber);
        SaveGameEvent saveGameEvent = new SaveGameEvent(savePosition);
        saveGameEvent.FireEvent();
    }
}