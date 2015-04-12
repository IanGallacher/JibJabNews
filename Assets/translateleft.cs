using UnityEngine;
using System.Collections;

public class translateleft : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x - 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
