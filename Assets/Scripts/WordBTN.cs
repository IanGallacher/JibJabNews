using UnityEngine;
using System.Collections;

public class Word {

	public int points = 2;
	public string word;
	public Word(string theword, int thepoints) {
		word = theword;
		points = thepoints;
	}
}
public class WordBTN : MonoBehaviour {
	bool hasbeenclicked = false;
	public Word word;
	void OnMouseDown() {
		if(!hasbeenclicked){
			GameObject wordManager = GameObject.Find ("MyWordList");
			wordManager.GetComponent<WordManager> ().AddWord (this);
			hasbeenclicked = true;
		}
	}
}