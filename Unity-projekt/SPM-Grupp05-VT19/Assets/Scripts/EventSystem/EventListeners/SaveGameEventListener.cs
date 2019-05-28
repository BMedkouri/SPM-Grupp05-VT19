//Author: Bilal El Medkouri

public class SaveGameEventListener : EventListener<SaveGameEvent>
{
    protected override void OnEvent(SaveGameEvent saveGameEvent)
    {
        GameManager.Instance.SaveGame(saveGameEvent.Position);
    }
}