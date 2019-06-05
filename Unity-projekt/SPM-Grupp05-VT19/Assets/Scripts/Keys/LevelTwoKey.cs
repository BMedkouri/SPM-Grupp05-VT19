//Author: Bilal El Medkouri

using UnityEngine;

public class LevelTwoKey : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private bool hasBeenTriggered;

    private void Awake()
    {
        button.SetActive(false);

        int hasKeyBeenPickedUp = PlayerPrefs.GetInt("levelTwoKey", 0);
        hasBeenTriggered = hasKeyBeenPickedUp == 1 ? true : false;

        if (hasBeenTriggered == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && other.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasBeenTriggered && Input.GetButtonDown("Xbox A"))
            {
                button.SetActive(false);
                hasBeenTriggered = true;
                other.GetComponent<Player>().Transition<PlayerPickUpState>();
                Player.Instance.HasLevelTwoKey = true;
                LevelManager.Instance.HasInteractableObjectBeenActivated = true;
                Destroy(gameObject, 2f);

                SaveGameEvent saveGameEvent = new SaveGameEvent(Player.Instance.transform.position);
                saveGameEvent.FireEvent();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!hasBeenTriggered && other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
