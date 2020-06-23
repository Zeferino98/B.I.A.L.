using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Dialogo : MonoBehaviour {


	public FalaNPC[] falas = new FalaNPC[1];
	public bool dialogoConcluido = false;
	bool emDialogo = false;

	DialogoController dialogoController;

	void Start () {
		dialogoController = FindObjectOfType <DialogoController>();
		Thread checar = new Thread (checarFimdefala);
		checar.Start ();
	}

	void Update () {
		if (emDialogo == true) {
			GameObject.Find("Player").GetComponent<PlayerMov>().movendo=false;
			if (Input.GetKey (KeyCode.Space)) {
				dialogoConcluido = true;
			}
		}

		if (dialogoConcluido == true) {
			GameObject.Find("Player").GetComponent<PlayerMov>().movendo=true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			dialogoController.ProximaFala (falas [0]);
			emDialogo = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		checarFimdefala ();
	}

	private void checarFimdefala(){
		emDialogo = false;
		dialogoConcluido = false;
	}
}
