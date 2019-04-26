using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LorePopupTextScript : MonoBehaviour
{

    public Canvas loreCanvas;

    public Image blackFade;
    private Text loreText;


    // Start is called before the first frame update
    void Start()
    {
        /* loreCanvas = GetComponent<Canvas>();
         blackFade = GetComponent<Image>();
         loreTextList = GetComponents<Text>(); */

        loreCanvas.gameObject.SetActive(true);

        blackFade.gameObject.SetActive(false);
    }

    public void OnMouseClick()
    {

        blackFade.gameObject.SetActive(!blackFade.gameObject.activeSelf);
        loreText.gameObject.SetActive(!loreText.gameObject.activeSelf);

        Debug.Log("ButtonClick");
    }

    public void SetLoreText(Text loreText)
    {
        this.loreText = loreText;
    }
}
