using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class DialogoBomDiaMestre : MonoBehaviour {

	public FalaNPC[] falas = new FalaNPC[3];
	public bool dialogoConcluido = false;
	bool emDialogo = false;
	int random = 0;

	DialogoController dialogoController;

	void Start () {
		dialogoController = FindObjectOfType <DialogoController>();
		Thread chec = new Thread (checarFimdefala);
		chec.Start ();
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
			random = Random.Range (0, 3);
			GameObject.Find("Player").GetComponent<PlayerMov>().movendo=false;
			dialogoController.ProximaFala (falas [random]);
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
