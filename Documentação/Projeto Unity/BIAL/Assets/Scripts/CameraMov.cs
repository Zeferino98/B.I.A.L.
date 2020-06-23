using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {

	public Transform target;
	public float velCam = 0.3f;

	void Update () {
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, velCam) + new Vector3 (0, 0, -10);
		}
	}
}
