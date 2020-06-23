using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverIntro : MonoBehaviour {
	public float vel = 0.5f;

	void Update() {
		transform.Translate (Vector2.left * vel * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other){
			vel = vel * -1;
	}
}
