//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine.SceneManagement;

public class ChangeLevelEventListener : EventListener<ChangeLevelEvent>
{
    protected override void OnEvent(ChangeLevelEvent changeLevel)
    {
        DebugEvent debugEvent = new DebugEvent("Transition to: " + changeLevel.Level);
        debugEvent.FireEvent();

        // TODO: FIX!
        //SoundEvent soundEvent = new SoundEvent(changeLevel.PlayerLocation, changeLevel.ChangeLevelSound);
        //soundEvent.FireEvent();

        SceneManager.LoadScene(changeLevel.Level);
    }
}
