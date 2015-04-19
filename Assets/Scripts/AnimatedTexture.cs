using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour {

	public Texture texture0;
	public Texture texture1;
	public Texture texture2;
	public Texture texture3;
	public float timedelay = 1.0f;

	private int framecount;
	private float deltatime;


	void Start () {
		framecount = 0;
		deltatime = 0;
	
	}

	void Update () {
		deltatime += Time.deltaTime;
		if(deltatime>timedelay) 
		{
			deltatime = 0;
			framecount++;
			if(framecount>1)
				framecount = 0;
		}
		if(framecount==0)
		{
			renderer.material.mainTexture = texture0;
		} if(framecount==1)
		{
			renderer.material.mainTexture = texture1;
		} if(framecount==2)
		{
			renderer.material.mainTexture = texture2;
		} if(framecount==3)
		{
			renderer.material.mainTexture = texture3;
		}
	
	}
}
