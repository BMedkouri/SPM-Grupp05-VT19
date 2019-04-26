using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreButtonTrigger : MonoBehaviour
{
    public Button loreButton;

    void Start()
    {

        loreButton.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            loreButton.gameObject.SetActive(true);
            Debug.Log("Trigger Enter");
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            loreButton.gameObject.SetActive(false);
            Debug.Log("Trigger Enter");
        }
    }
}
