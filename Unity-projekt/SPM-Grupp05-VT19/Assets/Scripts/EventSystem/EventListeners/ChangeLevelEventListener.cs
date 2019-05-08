using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelEventListener : MonoBehaviour
{
    private void Start()
    {
        ChangeLevelEvent.RegisterListener(OnChangeLevelEvent);
    }

    private void OnDestroy()
    {
        ChangeLevelEvent.UnregisterListener(OnChangeLevelEvent);
    }

    private void OnChangeLevelEvent(ChangeLevelEvent changeLevel)
    {
        DebugEvent debugEvent = new DebugEvent
        {
            DebugMessage = "Transition to: " + changeLevel.Level
        };
        debugEvent.FireEvent();

        SoundEvent soundEvent = new SoundEvent
        {
            AudioLocation = changeLevel.PlayerLocation,
            AudioSource = changeLevel.ChangeLevelSound
        };
        soundEvent.FireEvent();
        
        SceneManager.LoadScene(changeLevel.Level);
    }
}
