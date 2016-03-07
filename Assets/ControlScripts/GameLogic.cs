using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class GameLogic : MonoBehaviour {

	[SerializeField] private TextMesh scoreLabel;

	private int score = 0;

	private bool checkingMatch = false;

	private MemoryCard firstCard, secondCard;

	// Use this for initialization
	void Start () {
	
		scoreLabel = GameObject.Find ("Score Label").GetComponent<TextMesh> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckRevealedCards(MemoryCard card){

		if (firstCard != null) {
		
			secondCard = card;

			checkingMatch = true;

			StartCoroutine (CheckMatch());

		} else {
			firstCard = card;
		}
	}

	private IEnumerator CheckMatch(){

		yield return new WaitForSeconds (6.0f);

		if (secondCard.Image == firstCard.Image) {
			score++;

			scoreLabel.text = "Score: " + score;
		} else {
			secondCard.FlipFaceDown ();
			firstCard.FlipFaceDown ();

		}
	
		secondCard = null;
		firstCard = null;

		checkingMatch = false;

	}

	public void Restart(){

		SceneManager.LoadScene ("Menu_Scene");

	}

	public bool IsMatch(){
		return checkingMatch;
	}
		
}
