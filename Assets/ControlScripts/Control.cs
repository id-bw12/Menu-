using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {
	
	private UIMakerScript menu;

	private GameObject canvas, panel, eventSystem, text;

	private List<GameObject> buttons;

	private const float width = 125, length = 30;

	// Use this for initialization
	void Start () {

		menu = new UIMakerScript ();

		canvas = menu.CreateCanvas (this.transform);

		eventSystem = menu.CreateEventSystem (canvas.transform);

		panel = menu.CreatePanel (canvas.transform);

		buttons = new List<GameObject> ();

		MakeMainMenu ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MakeMainMenu(){

		text = menu.CreateText (panel.transform, 0, 40, 50, 25,"Main Menu", 12);

		buttons.Add(menu.CreateButton (panel.transform, -75, 0, width, length, "Play", delegate {Play();})); 

		buttons.Add(menu.CreateButton (panel.transform, 0, 0, width, length, "Options", delegate {Options();})); 

		buttons.Add(menu.CreateButton (panel.transform, 75, 0, width, length, "Exit", delegate {Exit();})); 
	}

	void Play(){

		DestroyObjects ();

		buttons.Clear ();

		text = null;

		GameObject.Destroy (canvas);

		GameObject.Destroy (panel);

		SetupBackground ();

		MakeScoreText ();

		MakeButton ();

		this.gameObject.AddComponent<GameLogic> ();

		this.gameObject.AddComponent<MakeDeck> ();

		this.gameObject.AddComponent<Timer> ();

	}

	void Options(){

		DestroyObjects ();

		buttons.Clear ();

		text = null;

		text = menu.CreateText (panel.transform, 0, 40, 50, 25,"Options Menu", 12);

		buttons.Add(menu.CreateButton (panel.transform, 0, 0, width, length, "Back", delegate {Back();})); 

	}

	void Exit(){
	

	}

	void Back(){

		DestroyObjects ();

		buttons.Clear ();

		text = null;

		MakeMainMenu ();

	}

	void DestroyObjects(){

		for (int i = 0; i < buttons.Count; ++i) {

			GameObject.Destroy (buttons [i]);
		}
			
		GameObject.Destroy (text);
	}

	void SetupBackground(){
		GameObject background = new GameObject ("Background");

		background.AddComponent<SpriteRenderer> ().sprite = Resources.Load ("table_top", typeof(Sprite)) as Sprite;

		background.transform.localScale = new Vector3 (3.0f, 2.0f, 1.0f);

		background.transform.position = new Vector3 (0.0f, 0.0f, 5f);	


	}

	void MakeScoreText()
	{

		GameObject text = new GameObject("Score Label");

		text.transform.position = new Vector3(-8.75f, 4.65f, 1.0f);

		text.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

		text.AddComponent<MeshRenderer>();

		text.AddComponent<TextMesh>();

		text.GetComponent<TextMesh>().text = "Score: ";

		text.GetComponent<TextMesh>().fontSize = 80;

	}

	void MakeButton()
	{

		GameObject button = new GameObject("UIButton");

		button.transform.position = new Vector3(8.0f, 4.25f, 1.0f);

		button.AddComponent<SpriteRenderer>().sprite = Resources.Load("start-button", typeof(Sprite)) as Sprite;

		button.AddComponent<BoxCollider2D>();

		button.AddComponent<UIButton>();

	}
}
