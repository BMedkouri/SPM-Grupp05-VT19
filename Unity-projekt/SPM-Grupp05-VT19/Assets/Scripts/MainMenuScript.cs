using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private int loadLevel;


    public void OnClickStartGame()
    {
        GameManager.Instance.LoadScene(loadLevel);

        Debug.Log("Main menu click");
    }
}
