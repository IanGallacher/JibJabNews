using UnityEngine;
using System.Collections;
using System.Collections.Generic;
enum GrammarType { Noun, Verb, Transition }
public class WordType {
	GrammarType grammartype;

}

public class WordManager : MonoBehaviour {

	public GameObject CustomWord;
	public float offsetX = 2.7f;
	public float offsetY = -10;

	List<GameObject> wordbank = new List<GameObject>();

	List<Word> currentPhrase = new List<Word>();

	int wordsinlist = 0;


	void Start() {
		GenerateWords ();
	}

	public bool isPhraseEmpty() {
		if(currentPhrase.Count <= 0) {
			return true;
		}
		print (currentPhrase.Count);
		return false;
	}

	float wordbank_offsetX = 0.0f;
	float wordbank_offsetY = 0.0f;
	
	
	float wordbox_offsetX = 0.0f;
	float wordbox_offsetY = 0.0f;
	protected void ResetWordBank() {
		string temp = "";
		foreach (Word word in currentPhrase) {
			temp += word.word;
			temp += " ";
		}
		GameObject.Find ("MyWordList").GetComponent<CaptionManager>().AddPhrase(temp);
		foreach(GameObject word in wordbank) {
			GameObject.Destroy(word.gameObject);
		}
		wordbank.Clear();
		currentPhrase.Clear();
		wordbank_offsetX = 0.0f;
		wordbank_offsetY = 0.0f;

		wordbox_offsetX = 0.0f;
		wordbox_offsetY = 0.0f;
	}
	public void GenerateWords() {

		FileIO loader = new FileIO();
		List<Word> templist = new List<Word> ();
		//we need to make a templist becasue the we are storing pointers to instances of gameobjects, not just a list of words. 

		//  todo: relative paths in unity. 
		  templist = loader.Load("C:\\Users\\Ian\\Documents\\GitHub\\JibJabNews\\Assets\\foxwords.txt");
		//templist = loader.Load("/Users/DrShenanigan/Desktop/JibJabNews/Assets/foxwords.txt");

		ResetWordBank();

		for(int x = 0; x<21; x++) {

			int r = Random.Range(0,20);
			GameObject Instance = (GameObject) Instantiate(CustomWord, new Vector3(0, 2.0f, 0.0f), Quaternion.identity);
			Instance.GetComponent<WordBTN>().word = templist[r];  

			//s et is a lis t with unique instances
			//shallow copy vs deep copy																																																																																																																				
		
			//if(word.word!=null)
			if(x>15) {
				print(x);
				print(Instance.GetComponent<WordBTN>().word.word);
				if(x==16) Instance.GetComponent<TextMesh>().text = Instance.GetComponent<WordBTN>().word.word = "Is";
				if(x==17) Instance.GetComponent<TextMesh>().text = Instance.GetComponent<WordBTN>().word.word = "Are";
				if(x==18) Instance.GetComponent<TextMesh>().text = Instance.GetComponent<WordBTN>().word.word = "Has";
				if(x==19) Instance.GetComponent<TextMesh>().text = Instance.GetComponent<WordBTN>().word.word = "To";
				if(x==20) Instance.GetComponent<TextMesh>().text = Instance.GetComponent<WordBTN>().word.word = "Have";
				Instance.GetComponent<WordBTN>().word.points = 0;
			} else {
				Instance.GetComponent<TextMesh>().text = templist[r].word;
			}

			Bounds boundingbox = Instance.GetComponent<TextMesh>().renderer.bounds;

			// Unity starts the coordinate system at the lower left for textobjects. Let's center the text. 
			BoxCollider collider = Instance.GetComponent<BoxCollider>();
			collider.center = new Vector3 (boundingbox.size.x/2, -0.29f, 0); 
			collider.size = new Vector3(boundingbox.size.x, 0.5f, 1);

			//2.7 and 5 are the coordinates that line up with the GUI texture in the background. 

			//if(wordbank_offsetX + boundingbox.size.x < 4) {
			Instance.transform.Translate(new Vector3(2.7f+wordbank_offsetX+offsetX,wordbank_offsetY+offsetY,0));
			//}
			wordbank_offsetX += boundingbox.size.x + 0.5f;
			if(wordbank_offsetX > 4) {
				wordbank_offsetX = 0;
				wordbank_offsetY -= 0.8f;
			}
			wordbank.Add(Instance);
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

	//c++  change the string without creating a new one.
	//c# and java create new strings.
	//trings are imutable
	//constrctor saves them as private to make them immutable

	int previously_added_words = 0;
	public void AddWord(WordBTN inputword) {
		inputword.transform.position = new Vector3 (wordbox_offsetX+2.7f+offsetX, wordbox_offsetY, 0);
		
		Bounds boundingbox = inputword.gameObject.GetComponent<TextMesh>().renderer.bounds;

		
		wordbox_offsetX += boundingbox.size.x + 0.5f;
		if(wordbox_offsetX > 4) {
			wordbox_offsetX = 0;
			wordbox_offsetY-=0.8f;
		}
		print (inputword.word.word);
		currentPhrase.Add(inputword.word);
		wordsinlist++;
		CalculateScore();
	}
}
