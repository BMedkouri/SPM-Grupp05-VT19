using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSaver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.SaveGame();
        gameObject.SetActive(false);
    }
}
