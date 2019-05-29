//Author: Bilal El Medkouri

using UnityEngine;

public class LevelOneChest : MonoBehaviour
{
    [SerializeField] private GameObject animationPosition;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject closedLid;
    [SerializeField] private GameObject openedLid;
    private bool hasBeenTriggered;

    private void Awake()
    {
        button.SetActive(false);
        closedLid.SetActive(true);
        openedLid.SetActive(false);

        int isChestOpen = PlayerPrefs.GetInt("levelOnechest", 0);
        hasBeenTriggered = isChestOpen == 1 ? true : false;

        if (hasBeenTriggered == true)
        {
            OpenChest();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenTriggered == false && other.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasBeenTriggered == false && Input.GetButtonDown("Xbox A"))
            {
                OpenChest(other);
            }
        }
    }

    private void OpenChest()
    {
        button.SetActive(false);
        hasBeenTriggered = true;
        closedLid.SetActive(false);
        openedLid.SetActive(true);

        LevelManager.Instance.HasInteractableObjectBeenActivated = true;
    }

    private void OpenChest(Collider other)
    {
        button.SetActive(false);
        hasBeenTriggered = true;
        closedLid.SetActive(false);
        openedLid.SetActive(true);

        SaveGameEvent saveGameEvent = new SaveGameEvent(Player.PlayerReference.transform.position);
        saveGameEvent.FireEvent();

        other.transform.position = animationPosition.transform.position;
        other.GetComponent<Player>().Transition<PlayerPickUpState>();

        LevelManager.Instance.HasInteractableObjectBeenActivated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasBeenTriggered == false && other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
