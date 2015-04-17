using UnityEngine;
using System.Collections;

public struct Word {//Todo: find out how to do shallowcopy lists of the set.

	public int points;
	// private string word { get; }
	public string word;
	//property and a field
	//field is a member lowercase
	//syntactic sugar
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