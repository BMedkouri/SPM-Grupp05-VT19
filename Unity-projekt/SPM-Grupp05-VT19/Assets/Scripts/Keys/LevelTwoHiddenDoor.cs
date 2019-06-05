//Author: Bilal El Medkouri

using UnityEngine;

public class LevelTwoHiddenDoor : MonoBehaviour
{
    public static LevelTwoHiddenDoor Instance;

    private Animator animator;

    [SerializeField] private GameObject button;
    private bool hasBeenTriggered;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();

        int isDoorOpen = PlayerPrefs.GetInt("levelTwoHiddenDoor", 0);
        hasBeenTriggered = isDoorOpen == 1 ? true : false;

        if (hasBeenTriggered == true)
        {
            OpenHiddenDoor();
        }

        button.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.Instance.HasLevelTwoKey == true && hasBeenTriggered == false && other.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.Instance.HasLevelTwoKey == true && hasBeenTriggered == false && Input.GetButtonDown("Xbox A"))
            {
                button.SetActive(false);
                hasBeenTriggered = true;
                Player.Instance.HasLevelTwoKey = false;

                SaveGameEvent saveGameEvent = new SaveGameEvent(Player.Instance.transform.position);
                saveGameEvent.FireEvent();

                OpenHiddenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Player.Instance.HasLevelTwoKey == true && hasBeenTriggered == false && other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }

    private void OpenHiddenDoor()
    {
        animator.SetTrigger("OpenHiddenDoor");
        LevelManager.Instance.HasDoorBeenOpened = true;
    }
}
