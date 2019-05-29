//Author: Bilal El Medkouri

using UnityEngine;

public class Gate : MonoBehaviour
{
    public static Gate Instance;

    private Animator animator;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();

        int hasTheGatesBeenOpened = PlayerPrefs.GetInt("levelOneDoor", 0);
        if (hasTheGatesBeenOpened == 1)
        {
            OpenTheGates();
        }
    }

    public void OpenTheGates()
    {
        animator.SetTrigger("OpenTheGates");
        LevelManager.Instance.HasDoorBeenOpened = true;
    }
}
