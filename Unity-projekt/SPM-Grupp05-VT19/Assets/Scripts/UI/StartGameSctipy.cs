using UnityEngine;

public class StartGameSctipy : MonoBehaviour
{

    [SerializeField] private int loadLevel;


    public void OnClickStartGame()
    {
        GameManager.Instance.LoadScene(loadLevel);
    }

    public void NewGame()
    {
        GameManager.Instance.NewGame();
    }


}
