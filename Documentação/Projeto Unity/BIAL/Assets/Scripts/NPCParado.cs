using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCParado : MonoBehaviour {

	private Animator animator;
	public int Dire;

	void Start () {
		animator = (Animator)this.GetComponent (typeof(Animator));
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Player") {
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
			animator.SetInteger ("Dir", Dire);
		}
	}
}
