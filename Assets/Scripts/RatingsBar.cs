using UnityEngine;
using System.Collections;

public class RatingsBar : MonoBehaviour {

	float myScore { get; set; }
	public float targetScore;

	void Start () {
		targetScore = 1000;
	}

	void Update() {
		gameObject.transform.localScale =  (new Vector3 (1, (myScore + 10) / targetScore, 1));
	}

	public void AddScore(float score) {
		myScore += score;
	}
}
