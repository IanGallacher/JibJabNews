using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	GameObject btnBackground;
	public GameObject buttonBackground;
	private Color startcolor;
	void Start () {


		btnBackground = (GameObject) Instantiate (buttonBackground);
		btnBackground.transform.parent = transform;
		Bounds boundingbox = gameObject.GetComponent<TextMesh>().renderer.bounds;
		btnBackground.transform.localPosition = new Vector3 (boundingbox.size.x/2, -0.4f, 0); 

		BoxCollider collider = btnBackground.GetComponent<BoxCollider>();
		btnBackground.transform.localScale = new Vector3(boundingbox.size.x*0.12f, 1f, 0.12f);
	}
	void OnMouseOver() 
	{
		startcolor = renderer.material.color;
		renderer.material.color = Color.yellow;
	}

	void OnMouseExit() 
	{
		renderer.material.color = Color.white; //startcolor
	}
}
