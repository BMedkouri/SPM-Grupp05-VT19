//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;
using UnityEngine.SceneManagement;

public class InvokeScene : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    public void InvokeDeathScene()
    {
        Invoke("EndGame", 3f);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
