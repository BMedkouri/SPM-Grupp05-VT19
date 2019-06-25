using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private int loadLevel;


    public void OnClickStartGame()
    {
        SceneManager.LoadScene(loadLevel);
        //GameManager.Instance.LoadScene(loadLevel);
        
    }
}
