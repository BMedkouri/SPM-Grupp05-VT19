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
        hasBeenTriggered = false;
        button.SetActive(false);
        closedLid.SetActive(true);
        openedLid.SetActive(false);
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
                button.SetActive(false);
                hasBeenTriggered = true;
                closedLid.SetActive(false);
                openedLid.SetActive(true);

                other.transform.position = animationPosition.transform.position;
                other.GetComponent<Player>().Transition<PlayerPickUpState>();

                LevelManager.Instance.HasInteractableObjectBeenActivated = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasBeenTriggered == false && other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
