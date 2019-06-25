using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LorePopupTextScript : MonoBehaviour
{

    public Canvas loreCanvas;

    public Image blackFade;
    private Text loreText;

    void Start()
    {

        loreCanvas.gameObject.SetActive(true);

        blackFade.gameObject.SetActive(false);
    }

    public void OnMouseClick()
    {

        blackFade.gameObject.SetActive(!blackFade.gameObject.activeSelf);
        loreText.gameObject.SetActive(!loreText.gameObject.activeSelf);

    }

    public void SetLoreText(Text loreText)
    {
        this.loreText = loreText;
    }
}
