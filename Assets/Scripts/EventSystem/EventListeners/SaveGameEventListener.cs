//Author: Bilal El Medkouri

public class SaveGameEventListener : EventListener<SaveGameEvent>
{
    protected override void OnEvent(SaveGameEvent saveGameEvent)
    {
        //DebugEvent debugEvent = new DebugEvent("Game saved.");
        //debugEvent.FireEvent();

        //GameManager.Instance.SaveGame(saveGameEvent.Position);
    }
}