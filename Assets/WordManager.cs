using UnityEngine;
using System.Collections;


enum GrammarType { Noun, Verb, Transition }
public class WordType {
	GrammarType grammartype;

}

public class WordManager : MonoBehaviour {

	Word[] wordbank = new Word[50];
	// List vs array c#
	//List<GameObject> phrase = new List<GameObject>();
	int wordsinlist = 0;

	public GameObject CustomWord;

	void Start() {
		GenerateWords (5);
	}
	float wordbank_offsetX = 0.0f;
	float wordbank_offsetY = 0.0f;
	public void GenerateWords(int wordcount) {
		float offset = 0.0f;
		FileIO loader = new FileIO();
		wordbank = loader.Load("C:\\Users\\Ian\\Documents\\GitHub\\JibJabNews\\Assets\\foxwords.txt");
		foreach(Word word in wordbank) {
			//we have to instantiate the word before the renderer knows what size the bounds are. 
			//The screen won't jump because unity won't draw this until after the function is finished. 
			GameObject Instance = (GameObject) Instantiate(CustomWord, new Vector3(0, 2.0f, 0.0f), Quaternion.identity);

			print (wordbank[0].word);
			int x = 0;

			print (x);
			x++;
			//if(word.word!=null)
			Instance.GetComponent<TextMesh>().text = word.word;


			Bounds boundingbox = Instance.GetComponent<TextMesh>().renderer.bounds;

			// Unity starts the coordinate system at the lower left for textobjects. Let's center the text. 
			BoxCollider collider = Instance.GetComponent<BoxCollider>();
			collider.center = new Vector3 (boundingbox.size.x/2, 0, 0); 
			collider.size = new Vector3(boundingbox.size.x, 0.5f, 1);


			Instance.transform.Translate(new Vector3(-8+wordbank_offsetX,wordbank_offsetY,0));
			offset += boundingbox.size.x + 0.1f;
			wordbank_offsetX += boundingbox.size.x + 0.5f;
			if(wordbank_offsetX > 4) {
				wordbank_offsetX = 0;
				wordbank_offsetY-=1.0f;
			}
		}
	}

	public int CalculateScore() {
		int score = 0;
		foreach(Word word in wordbank){
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
		inputword.transform.position = new Vector3 (wordbox_offsetX, wordbox_offsetY, 0);
		
		Bounds boundingbox = inputword.gameObject.GetComponent<TextMesh>().renderer.bounds;

		
		wordbox_offsetX += boundingbox.size.x;
		if(wordbox_offsetX > 4) {
			wordbox_offsetX = 0;
			wordbox_offsetY-=1.5f;
		}
		print (wordbox_offsetX);


		//wordbank [wordsinlist] = inputword;
		wordsinlist++;
		CalculateScore();
	}
}
