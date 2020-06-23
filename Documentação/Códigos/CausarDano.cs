using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class CausarDano : MonoBehaviour {

	public int vida;
	float tempoinvul;
	public float tempoinvencivel;
	int layerobjeto;
	SpriteRenderer spriteRend;
	public float invulAnimTempo = 0.1f;
	public bool check;

	void Start (){
		layerobjeto = gameObject.layer;
		spriteRend = GetComponent<SpriteRenderer> ();
		Thread tempo = new Thread (TempoInvul);
		tempo.Start ();
		Thread dano = new Thread (TomarDano);
		dano.Start ();

		if (spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer> ();
			if (spriteRend == null) {
				Debug.LogError ("Deu ruim!");
			}
		}
	}

	void Update (){
		TempoInvul ();

		if (tempoinvul <= 0) {
			gameObject.layer = layerobjeto;
			if (spriteRend != null) {
				spriteRend.enabled = true;
			}
		} else {
			if (spriteRend != null) {
				if (check == false) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		if (vida <= 0) {
			Morrer ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Projetil") {
			Debug.Log ("atingiu!");
			TomarDano ();
			tempoinvul = tempoinvencivel;
			gameObject.layer = 11;
		}
	}

	void TomarDano(){
		vida--;
	}

	void TempoInvul(){
		if (invulAnimTempo > 0) {
			invulAnimTempo -= Time.deltaTime;
			check = true;
		}

		if (invulAnimTempo <= 0) {
			check = false;
			invulAnimTempo = 0.1f;
		}

		if (tempoinvul > 0) {
			tempoinvul -= Time.deltaTime;
		}
	}

	void Morrer(){
		if (gameObject.tag == "Player") {
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}

		if (gameObject.tag == "Inimigo") {
			SceneManager.LoadScene ("Vitoria", LoadSceneMode.Single);
		}
	}
}
