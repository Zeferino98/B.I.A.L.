using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag != "Player") {
			return;
		} else {
			Debug.Log ("Colidiu");
			SceneManager.LoadScene ("BatalhaBoss", LoadSceneMode.Single);
		}
	}
}
