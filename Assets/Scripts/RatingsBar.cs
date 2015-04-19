using UnityEngine;
using System.Collections;

public class RatingsBar : MonoBehaviour {

	float _myScore;
	float myScore 
	{ 
		get { return _myScore; }
		set { 
			if(value>(1000-10)) {
				_myScore = 1000;
			}
			else {
				_myScore = value;
			}
		}
	}

	public float targetScore;

	void Start () {
		targetScore = 1000;
	}

	void Update() {
		gameObject.transform.localScale =  (new Vector3 (1, (myScore + 10) / targetScore, 1));
	}

	public void AddScore(float score) {
		myScore = myScore + score;
	}
}
