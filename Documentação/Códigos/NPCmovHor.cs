using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovHor : MonoBehaviour {
	private Animator animator;
	public int vel;
	public int Dire=4;

	void Start () {
		animator = (Animator)this.GetComponent (typeof(Animator));
	}

	void Update() {
		transform.Translate (Vector2.left * vel * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag != "Player") {
			vel = vel * -1;
			if (Dire == 4) {
				animator.SetInteger ("Dir", 2);
				Dire = 2;
			} else {
				animator.SetInteger ("Dir", 4);
				Dire = 4;
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
			if (Dire == 4) {
				vel = vel + 1;
				animator.SetInteger ("Dir", 4);
			} else {
				vel = vel - 1;
				animator.SetInteger ("Dir", 2);
			}
			animator.SetBool ("Mov", true);
		}
	}
}