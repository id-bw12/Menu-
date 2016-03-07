using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MemoryCard : MonoBehaviour {

	[SerializeField] private GameLogic logic;

    private Timer gameTimer;

	private Sprite card, backImage;

	// Use this for initialization
	void Start () {

        gameTimer = GameObject.Find("Control Object").GetComponent<Timer>();

        backImage = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
		logic = GameObject.Find ("Control Object").GetComponent<GameLogic> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		
		if(!gameTimer.Enable && !logic.IsMatch()){
			
	        gameTimer.SetTimeLimit();

			gameTimer.SetCard (this);

			gameTimer.Enable = true;

	        logic.CheckRevealedCards(this);
	    }
	}

    public void CardFlips( float yRotation) {

        int y = (int)yRotation;

        if (y >= 0 && y <= 90)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = backImage;
        else
            if (y >= 90 && y <= 270)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = card;
        else
            if (y >= 270 && y <= 360)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = backImage;

    }

    public Sprite Image{
		get{ return this.card;}
		set{ this.card = value;}
	}

	public void FlipFaceDown(){

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = backImage;

		this.transform.Rotate(0.0f, 0.0f, 0.0f);
	}

	public void FlipFaceUp(){

		this.gameObject.GetComponent<SpriteRenderer>().sprite = card;

	}
}
