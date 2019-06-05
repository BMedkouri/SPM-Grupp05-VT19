using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameSctipy : MonoBehaviour
{

    [SerializeField] private int loadLevel;


    public void OnClickStartGame()
    {
        SceneManager.LoadScene(loadLevel);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }


}
