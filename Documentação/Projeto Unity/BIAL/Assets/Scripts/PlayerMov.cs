using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
	private Animator animator;
	public float velocidade;
	public bool movendo = true;

	void Start () {
		animator = (Animator)this.GetComponent (typeof(Animator));
	}

	void FixedUpdate () {
		Movimentação();
	}

	public void Movimentação(){
		if (movendo == false) {
			animator.SetBool ("Movimento", false);
		}

		if (movendo == true) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") != 0) {
					animator.SetBool ("Movimento", false);
					velocidade = 0;
				} else {
					velocidade = 3;
					animator.SetFloat ("Velocidade", 3);
				}
			}

			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				velocidade = 2;
				animator.SetFloat ("Velocidade", 2);
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (Vector2.right * velocidade * Time.deltaTime);
				animator.SetBool ("Movimento", true);
				animator.SetInteger ("Direcao", 2);
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Translate (Vector2.left * velocidade * Time.deltaTime);
				animator.SetBool ("Movimento", true);
				animator.SetInteger ("Direcao", 4);
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (Vector2.up * velocidade * Time.deltaTime);
				animator.SetBool ("Movimento", true);
				animator.SetInteger ("Direcao", 1);
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (Vector2.down * velocidade * Time.deltaTime);
				animator.SetBool ("Movimento", true);
				animator.SetInteger ("Direcao", 3);
			}

			if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0) {
				animator.SetBool ("Movimento", false);
			}

			if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") != 0) {
				animator.SetBool ("Movimento", false);
				velocidade = 0;
			} else {
				velocidade = 2;
			}
		}
}
}