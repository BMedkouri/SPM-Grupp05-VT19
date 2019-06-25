//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// Rotates the enemies canvas towards the player, through the main camera.
/// </summary>
public class EnemyCanvasController : MonoBehaviour
{
    private Vector3 targetPosition;

    private void Update()
    {
        targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
