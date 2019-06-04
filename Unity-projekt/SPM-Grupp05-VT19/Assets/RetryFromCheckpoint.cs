using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryFromCheckpoint : MonoBehaviour
{

    public void RetryCheckpoint()
    {
        GameManager.Instance.LoadGame();
    }
}
