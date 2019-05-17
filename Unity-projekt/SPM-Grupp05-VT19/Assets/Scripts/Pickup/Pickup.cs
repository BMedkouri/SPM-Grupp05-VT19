//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
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
                closedLid.SetActive(false);
                openedLid.SetActive(true);

                other.transform.position = animationPosition.transform.position;
                other.GetComponent<Player>().Transition<PlayerPickUpState>();
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
