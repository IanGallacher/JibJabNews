using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	GameObject btnBackground;
	public GameObject buttonBackground;
	void Start () {
		btnBackground = (GameObject) Instantiate (buttonBackground);
		Bounds boundingbox = gameObject.GetComponent<TextMesh>().renderer.bounds;
		btnBackground.transform.position = new Vector3 (boundingbox.size.x/2, -0.29f, 0); 

		BoxCollider collider = btnBackground.GetComponent<BoxCollider>();
		btnBackground.transform.localScale = new Vector3(boundingbox.size.x*0.2f, 0.1f, 0.2f);
	}
}
