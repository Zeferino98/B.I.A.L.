using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class NPCBattleMov : MonoBehaviour {

	public Transform player;
	public float vel;
	public float cooldownTiro = 0;
	public float delayTiro = 1f;
	public GameObject projetilPrefab;
	public GameObject Anim;
	Vector3 ProjetilOffset = new Vector3 (-0.8f, -1f, 0);
	Vector3 ProjetilOffsetEspelho = new Vector3 (0.8f, -1f, 0);
	Vector3 ProjetilAnimOffset = new Vector3 (-0.25f, 0.8f, 0);
	Vector3 ProjetilAnimOffsetEspelho = new Vector3 (0.25f, 0.8f, 0);
	public bool Espelho = true;

	void Start (){
		Thread InimCD = new Thread (InimCD_Tiro);
		InimCD.Start ();
	}
	void Update () {
		InimCD_Tiro ();

		if (cooldownTiro <= 0) {
			Debug.Log ("Inimigo Atirando");
			cooldownTiro = delayTiro;
			if (Espelho == false) {
				Vector3 offset = transform.rotation * ProjetilOffset;
				Instantiate (projetilPrefab, (transform.position + offset), transform.rotation);
				Instantiate (Anim, (transform.position + offset + ProjetilAnimOffset), transform.rotation);
				Espelho = true;
			} else {
				Vector3 offset = transform.rotation * ProjetilOffsetEspelho;
				Instantiate (projetilPrefab, (transform.position + offset), transform.rotation);
				Instantiate (Anim, (transform.position + offset + ProjetilAnimOffsetEspelho), transform.rotation);
				Espelho = false;
			}
		}

		transform.position = Vector2.MoveTowards (transform.position, player.position, vel * Time.deltaTime);
	}

	void InimCD_Tiro (){
		if (cooldownTiro > 0) {
			cooldownTiro -= Time.deltaTime;
		}
	}
}
