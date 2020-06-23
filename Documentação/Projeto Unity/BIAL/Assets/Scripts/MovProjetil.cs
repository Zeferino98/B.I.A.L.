using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovProjetil : MonoBehaviour {

	public int velocidadeProjetil = 8;
	public GameObject Hit;

	void Update (){
		Vector3 pos = transform.position;

		Vector3 velocidade = new Vector3 (0, velocidadeProjetil * Time.deltaTime, 0);

		pos += velocidade;

		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Projetil") {
			Instantiate (Hit, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
