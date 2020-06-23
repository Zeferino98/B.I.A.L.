using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Fader : MonoBehaviour {

	Animator anim;
	bool Fading = false;

	void Start () {
		anim = GetComponent<Animator> ();
		Thread t = new Thread (AnimationComplete);
		t.Start ();
	}

	public IEnumerator FadeToClear(){
		Fading = true;
		anim.SetTrigger ("FadeIn");

		while (Fading)
			yield return null;
	}

	public IEnumerator FadeToBlack(){
		Fading = true;
		anim.SetTrigger ("FadeOut");

		while (Fading)
			yield return null;
	}

	void AnimationComplete (){
		Fading = false;
	}

}
