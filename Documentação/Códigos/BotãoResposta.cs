﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotãoResposta : MonoBehaviour {

	Resposta respostaData;

	public void ProximaFala() {
		FindObjectOfType<DialogoController>().ProximaFala(respostaData.proximaFala);
	}

	public void Setup(Resposta resposta) {
		respostaData = resposta;
	}
}

