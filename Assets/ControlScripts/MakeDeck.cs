using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MakeDeck : MonoBehaviour {

	private List<GameObject> deck = new List<GameObject> ();

	private Sprite[] cardImages = new Sprite[4];

	// Use this for initialization
	void Start () {

		float x = -3.0f, y = 2.0f, z = 2.0f;
	
		LoadCardImages ();
	
		for (int i = 0; i < 8; ++i) {

			MakeMemoryCard (cardImages [i % 4], new Vector3 (x, y, z));

			x += 3.0f;

			if (i == 3) {
				y = -1.0f;
				x = -3.0f;
			}
		}

		ShuffleImages ();
		//Debug.Log (deck.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadCardImages(){

		cardImages [0] = Resources.Load ("crescent-symbol", typeof(Sprite)) as Sprite;
		cardImages [1] = Resources.Load ("diamond-symbol", typeof(Sprite)) as Sprite;
		cardImages [2] = Resources.Load ("heart-symbol", typeof(Sprite)) as Sprite;
		cardImages [3] = Resources.Load ("square-symbol", typeof(Sprite)) as Sprite;
	}

	void ShuffleImages(){
	
		Sprite tempSprite;

		int j;

		for(int i = 0; i < 8; ++i){

			tempSprite = deck[i].gameObject.GetComponent<MemoryCard>().Image;

			j = Random.Range (0,7);

			deck[i].gameObject.GetComponent<MemoryCard>().Image = deck[j].gameObject.GetComponent<MemoryCard>().Image;

			deck[j].gameObject.GetComponent<MemoryCard>().Image = tempSprite;

		}
	}

	void MakeMemoryCard(Sprite cardImage , Vector3 position){

		GameObject memoryCard = new GameObject ("Card");

		Sprite cardSprite = Resources.Load ("card_back", typeof(Sprite)) as Sprite;

		memoryCard.transform.position = position;

		memoryCard.AddComponent<SpriteRenderer> ();

		memoryCard.AddComponent<BoxCollider2D> ();

		memoryCard.GetComponent<SpriteRenderer> ().sprite = cardSprite;

		memoryCard.AddComponent<MemoryCard> ();

		memoryCard.GetComponent<MemoryCard> ().Image = cardImage;

		deck.Add(memoryCard.gameObject);

	}

}
