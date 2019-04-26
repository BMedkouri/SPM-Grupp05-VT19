using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LorePopupTextScript : MonoBehaviour
{

    public Canvas loreCanvas;

    private bool isVisible;

    public Image blackFade;
    public Text[] loreTextList;
    

    // Start is called before the first frame update
    void Start()
    {
       /* loreCanvas = GetComponent<Canvas>();
        blackFade = GetComponent<Image>();
        loreTextList = GetComponents<Text>(); */

        loreCanvas.enabled = true;

        blackFade.enabled = false;
        isVisible = false;
    }
    
    public void OnClick()
    {
   

        if (Input.GetKeyDown("Fire1"))
        {
            if(isVisible == false)
            {
                blackFade.enabled = true;
                isVisible = true;
            }
        }
        else
        {
            blackFade.enabled = false;
            isVisible = false;
        }
      

        Debug.Log("ButtonClick");
    }

}
