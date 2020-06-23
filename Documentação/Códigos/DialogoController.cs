using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour {

	public GameObject painelDeDialogo;

	public Text falaNPC;

	public GameObject resposta;

	private bool falaAtiva = false;

	FalaNPC falas;

	void Update () {

		if (Input.GetKey (KeyCode.Space) && falaAtiva) {
			if (falas.respostas.Length > 0) 
				MostrarRespostas ();
			else {
				falaAtiva = false;
				painelDeDialogo.SetActive (false);
				falaNPC.gameObject.SetActive (false);
			}
		}
	}

	void MostrarRespostas() {
		falaNPC.gameObject.SetActive (false);
		falaAtiva = false;
		for (int i = 0; i < falas.respostas.Length; i++) {
			GameObject tempResposta = Instantiate (resposta, painelDeDialogo.transform) as GameObject;
			tempResposta.GetComponent<Text> ().text = falas.respostas [i].resposta;
			tempResposta.GetComponent<BotãoResposta> ().Setup (falas.respostas [i]);
		}
	}

	public void ProximaFala(FalaNPC fala){
		falas = fala;
		LimparRespostas();
		falaAtiva = true;
		painelDeDialogo.SetActive (true);
		falaNPC.gameObject.SetActive (true);
		falaNPC.text = falas.fala;
	}

	void LimparRespostas() {
		BotãoResposta[] botoes = FindObjectsOfType<BotãoResposta>();
		foreach (BotãoResposta botao in botoes) {
			Destroy(botao.gameObject);
		}
	}
}