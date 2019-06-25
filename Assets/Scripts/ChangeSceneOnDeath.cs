using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDeath : MonoBehaviour
{
    [SerializeField] private int loadLevel;
    private void OnDestroy()
    {

        SceneManager.LoadScene(loadLevel);
    }
}
