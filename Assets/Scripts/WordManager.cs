using UnityEngine;
using System.Collections;
using System.Collections.Generic;
enum GrammarType { Noun, Verb, Transition }
public class WordType {
	GrammarType grammartype;

}

public class WordManager : MonoBehaviour {

	Word[] wordbank = new Word[50];

	List<Word> currentPhrase = new List<Word>();

	int wordsinlist = 0;

	public GameObject CustomWord;

	void Start() {
		GenerateWords ();
	}
	float wordbank_offsetX = 0.0f;
	float wordbank_offsetY = 0.0f;
	public void GenerateWords() {

		FileIO loader = new FileIO();
		wordbank = loader.Load("C:\\Users\\Ian\\Documents\\GitHub\\JibJabNews\\Assets\\foxwords.txt");
		for(int x = 0; x<10; x++) {
			int r = Random.Range(0,20);
			GameObject Instance = (GameObject) Instantiate(CustomWord, new Vector3(0, 2.0f, 0.0f), Quaternion.identity);
			Instance.GetComponent<WordBTN>().word = wordbank[r];


			x++;
			//if(word.word!=null)
			Instance.GetComponent<TextMesh>().text = wordbank[r].word;


			Bounds boundingbox = Instance.GetComponent<TextMesh>().renderer.bounds;

			// Unity starts the coordinate system at the lower left for textobjects. Let's center the text. 
			BoxCollider collider = Instance.GetComponent<BoxCollider>();
			collider.center = new Vector3 (boundingbox.size.x/2, -0.29f, 0); 
			collider.size = new Vector3(boundingbox.size.x, 0.5f, 1);

			//2.7 and 5 are the coordinates that line up with the GUI texture in the background. 

			//if(wordbank_offsetX + boundingbox.size.x < 4) {
				Instance.transform.Translate(new Vector3(2.7f+wordbank_offsetX,wordbank_offsetY+2,0));
			//}
			wordbank_offsetX += boundingbox.size.x + 0.5f;
			if(wordbank_offsetX > 4) {
				wordbank_offsetX = 0;
				wordbank_offsetY -= 0.8f;
			}
		}
	}

	public int CalculateScore() {
		int score = 0;
		foreach(Word word in currentPhrase){
			//if(word)
				score += word.points;
		}
		print (score);
		return score;
	}
	
	float wordbox_offsetX = 0.0f;
	float wordbox_offsetY = 0.0f;

	int previously_added_words = 0;
	public void AddWord(WordBTN inputword) {
		inputword.transform.position = new Vector3 (wordbox_offsetX+2.7f, wordbox_offsetY-1, 0);
		
		Bounds boundingbox = inputword.gameObject.GetComponent<TextMesh>().renderer.bounds;

		
		wordbox_offsetX += boundingbox.size.x + 0.5f;
		if(wordbox_offsetX > 4) {
			wordbox_offsetX = 0;
			wordbox_offsetY-=0.8f;
		}

		currentPhrase.Add(inputword.word);
		wordsinlist++;
		CalculateScore();
	}
}
