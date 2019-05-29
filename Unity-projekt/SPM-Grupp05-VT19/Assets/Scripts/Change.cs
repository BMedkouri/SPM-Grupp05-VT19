using UnityEngine;

public class Change : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(2);
        }
    }
}
