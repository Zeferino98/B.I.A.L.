using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoGuarda : MonoBehaviour {

	public FalaNPC[] falas = new FalaNPC[2];
	public bool dialogoConcluido = false;
	bool emDialogo = false;
	public int vel = 1;
	private Animator animator;
	bool fim = false;
	public bool Transitando = false;

	DialogoController dialogoController;

	void Start () {
		animator = (Animator)this.GetComponent (typeof(Animator));
		dialogoController = FindObjectOfType <DialogoController>();
	}

	void Update () {
		if (emDialogo == true) {
			GameObject.Find ("Player").GetComponent<PlayerMov> ().movendo = false;
			if (Input.GetKey (KeyCode.Space)) {
				dialogoConcluido = true;
			}
		}

		if (dialogoConcluido == true) {
			if (fim == false) {
				animator.SetBool ("Mov", true);
				animator.SetInteger ("Dir", 2);
				transform.Translate (Vector2.right * vel * Time.deltaTime);
			}
			if (Transitando == false) {
				GameObject.Find ("Player").GetComponent<PlayerMov> ().movendo = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			dialogoConcluido = false;
			emDialogo = true;
			if (fim == false) {
				dialogoController.ProximaFala (falas [0]);
			} else {
				dialogoController.ProximaFala (falas [1]);
			}
		} else {
			fim = true;
			animator.SetBool ("Mov", false);
			animator.SetInteger ("Dir", 3);
			vel = 0;
		}
	}
}
