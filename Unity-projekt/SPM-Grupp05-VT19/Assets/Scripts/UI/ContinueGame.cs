using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    private void OnMouseOver()
    {
        GameManager.Instance.LoadGame();
    }
}
