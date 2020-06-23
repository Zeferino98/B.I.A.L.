using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transições : MonoBehaviour {

	public Transform TransicaoAlvo;
		
	IEnumerator OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Debug.Log ("teste");
			GameObject.Find("Player").GetComponent<PlayerMov>().movendo=false;
			GameObject.Find("Guardinha").GetComponent<DialogoGuarda>().Transitando=true;
			Fader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<Fader> ();
			yield return StartCoroutine (sf.FadeToBlack ());
			other.gameObject.transform.position = TransicaoAlvo.position;
			Camera.main.transform.position = TransicaoAlvo.position;
			yield return StartCoroutine (sf.FadeToClear ());
			GameObject.Find("Player").GetComponent<PlayerMov>().movendo=true;
			GameObject.Find("Guardinha").GetComponent<DialogoGuarda>().Transitando=false;
		}
	}
}