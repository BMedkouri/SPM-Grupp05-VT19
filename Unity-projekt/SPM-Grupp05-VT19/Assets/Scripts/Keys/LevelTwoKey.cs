//Author: Bilal El Medkouri

using UnityEngine;

public class LevelTwoKey : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private bool hasBeenTriggered;

    private void Awake()
    {
        hasBeenTriggered = false;
        button.SetActive(false);
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
                Player.PlayerReference.HasLevelTwoKey = true;
                Destroy(gameObject, 2f);
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
