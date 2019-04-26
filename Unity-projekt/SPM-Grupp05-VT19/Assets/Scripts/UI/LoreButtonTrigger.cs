﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreButtonTrigger : MonoBehaviour
{
    public Button loreButton;
    public Text loreText;
    private LorePopupTextScript lorePopupTextScript;

    void Start()
    {
        loreButton.gameObject.SetActive(false);
        lorePopupTextScript = loreButton.GetComponent<LorePopupTextScript>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            lorePopupTextScript.SetLoreText(loreText);
            loreButton.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            loreButton.gameObject.SetActive(false);
            lorePopupTextScript.gameObject.SetActive(false);
        }
    }
}
