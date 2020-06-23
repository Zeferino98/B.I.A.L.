using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovVer : MonoBehaviour {
	private Animator animator;
	public int vel;
	public int Dire=1;

	void Start () {
		animator = (Animator)this.GetComponent (typeof(Animator));
	}

	void Update() {
		transform.Translate (Vector2.up * vel * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag != "Player") {
			vel = vel * -1;
			if (Dire == 1) {
				animator.SetInteger ("Dir", 3);
				Dire = 3;
			} else {
				animator.SetInteger ("Dir", 1);
				Dire = 1;
			}

		}


		if (other.tag == "Player") {
			vel = vel * 0;
			animator.SetBool ("Mov", false);
			if (gameObject.GetComponent<DirectionRaycasting2DCollider> ().collisionDown) {
				animator.SetInteger ("Dir", 3);
			}
			if (gameObject.GetComponent<DirectionRaycasting2DCollider> ().collisionUp) {
				animator.SetInteger ("Dir", 1);
			}
			if (gameObject.GetComponent<DirectionRaycasting2DCollider> ().collisionLeft) {
				animator.SetInteger ("Dir", 4);
			}
			if (gameObject.GetComponent<DirectionRaycasting2DCollider> ().collisionRight) {
				animator.SetInteger ("Dir", 2);
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Player") {
			if (Dire == 1) {
				vel = vel + 1;
				animator.SetInteger ("Dir", 1);
			} else {
				vel = vel - 1;
				animator.SetInteger ("Dir", 3);
			}
			animator.SetBool ("Mov", true);
		}
	}
}