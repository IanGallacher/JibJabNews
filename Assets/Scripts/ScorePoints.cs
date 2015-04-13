using UnityEngine;
using System.Collections;

public class ScorePoints : MonoBehaviour {
	GameObject wordManager;
	GameObject scorebar; 
	void Start () {
		wordManager = GameObject.Find ("MyWordList");
		scorebar = GameObject.Find ("ScoreBar");
	}

	void OnMouseDown() {
		scorebar.GetComponent<RatingsBar>().AddScore(
			wordManager.GetComponent<WordManager>().CalculateScore()
		);
		//wordManager.GetComponent<WordManager>().GenerateWords();
	}
}
