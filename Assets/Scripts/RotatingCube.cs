using UnityEngine;
using System.Collections;

public class RotatingCube : MonoBehaviour {
	void Update () {
		Vector3 a = gameObject.transform.eulerAngles;
		gameObject.transform.eulerAngles = new Vector3 (a.x, a.y + 1, a.z);
	}
}
