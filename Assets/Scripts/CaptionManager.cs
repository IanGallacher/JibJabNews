using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaptionManager : MonoBehaviour {

	public GameObject basetext;
	public float offsetY = -3.0f;
	GameObject leftmostobj;
	List<GameObject> captionqueue = new List<GameObject>();
	List<Word> phraselist = new List<Word> ();
	void Start() {
		FileIO loader = new FileIO();
		phraselist = loader.LoadPhrase (Application.dataPath+"/Headlines.txt");
		for(int x=0;x<3;x++) {
			int r = Random.Range(0,phraselist.Count-1);
			AddPhrase (phraselist[r].word);
		}
	}

	void Update() {
		GameObject deleteme = null;
		foreach (GameObject thing in captionqueue) {
			thing.transform.Translate(new Vector3(-1*Time.deltaTime,0,0));
			Bounds boundingbox = thing.gameObject.GetComponent<TextMesh>().renderer.bounds;
			if (boundingbox.size.x+thing.transform.position.x < -10) {
				deleteme = thing;
			}

			
			boundingbox = leftmostobj.gameObject.GetComponent<TextMesh>().renderer.bounds;
			if(boundingbox.size.x+leftmostobj.transform.position.x < 10) {
				int r = Random.Range(0,phraselist.Count-1);
				AddPhrase (phraselist[r].word);
			}
		}
		if(deleteme) {
			captionqueue.Remove (deleteme);
			GameObject.Destroy(deleteme.gameObject);
		}
	}
	public void AddPhrase(string inputword) {
		GameObject Instance;
		if(captionqueue.Count == 0) {
			Instance = (GameObject) Instantiate (basetext, new Vector3 (0, offsetY, 0), Quaternion.identity);
			Instance.GetComponent<TextMesh>().text = inputword;
			leftmostobj = Instance;
		} else {
			Instance = (GameObject) Instantiate (basetext, new Vector3 (0, -2, 0), Quaternion.identity);
			Instance.GetComponent<TextMesh>().text = inputword;
			Bounds boundingbox = leftmostobj.gameObject.GetComponent<TextMesh>().renderer.bounds;
			Instance.transform.position = new Vector3(boundingbox.size.x+leftmostobj.transform.position.x + 2.0f, offsetY,0);
			leftmostobj = Instance;
		}


		captionqueue.Add (Instance);

//
//		inputword.transform.position = new Vector3 (wordbox_offsetX+2.7f, wordbox_offsetY-1, 0);
//		
//		Bounds boundingbox = inputword.gameObject.GetComponent<TextMesh>().renderer.bounds;
//		
//		
//		wordbox_offsetX += boundingbox.size.x + 0.5f;
//		if(wordbox_offsetX > 4) {
//			wordbox_offsetX = 0;
//			wordbox_offsetY-=0.8f;
//		}
//		print (wordbox_offsetX);
//		
//		
//		//wordbank [wordsinlist] = inputword;
//		wordsinlist++;
//		CalculateScore();
	}
}
