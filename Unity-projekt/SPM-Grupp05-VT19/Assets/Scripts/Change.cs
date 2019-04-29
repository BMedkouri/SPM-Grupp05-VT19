using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
	[SerializeField] private string loadLevel;
//	public Animator animator;

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			SceneManager.LoadScene(loadLevel);
		
		}
	}
    /*
	public void FadeToLevel(int levelIndex) {
		animator.SetTrigger("FadeOut");
	}
    */
}
