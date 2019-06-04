using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    public void OnMouseOver()
    {
        GameManager.Instance.LoadGame();
    }
}
