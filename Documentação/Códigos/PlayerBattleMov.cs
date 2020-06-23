using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerBattleMov : MonoBehaviour {

	public GameObject projetilPrefab;
	float velocidade = 5;
	private Animator animator;
	float cooldownTiro = 0;
	public float delayTiro = 0.5f;

	// Use this for initialization
	void Start () {
		Thread CD = new Thread (CD_Tiro);
		CD.Start ();
		animator = (Animator)this.GetComponent (typeof(Animator));
	}
	
	// Update is called once per frame
	void Update () {
		CD_Tiro ();
		Movimentação ();
	}

	public void Movimentação(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector2.left * velocidade * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.Space) && cooldownTiro <=0) {
			Debug.Log ("Atirando!");
			animator.SetBool ("Atacando", true);
			cooldownTiro = delayTiro;
			Vector3 offset = transform.rotation * new Vector3 (0, 1f, 0);
			Instantiate (projetilPrefab, transform.position + offset, transform.rotation);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			Debug.Log ("Parou de atirar!");
			animator.SetBool ("Atacando", false);
		}
	}

	void CD_Tiro (){
		if (cooldownTiro > 0) {
			cooldownTiro -= Time.deltaTime;
		}
	}

}
