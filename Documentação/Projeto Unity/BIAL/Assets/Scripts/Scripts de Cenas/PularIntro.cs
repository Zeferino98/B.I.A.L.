using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PularIntro : MonoBehaviour {
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			SceneManager.LoadScene ("EntradaFatec", LoadSceneMode.Single);
		}	
	}
}
