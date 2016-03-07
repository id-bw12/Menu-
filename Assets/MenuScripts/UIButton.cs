using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {

	[SerializeField]private GameObject targetObject;

	[SerializeField]private string targetMessage;

	public Color highlightColor = Color.cyan;

	// Use this for initialization
	void Start () {

		targetObject = GameObject.Find ("Control Object");

		targetMessage = "Restart";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseOver(){

		var sprite = GetComponent<SpriteRenderer> ();

		if (sprite != null)
			sprite.color = highlightColor;
	}

	public void OnMouseExit(){
	
		var sprite = GetComponent<SpriteRenderer> ();

		if (sprite != null)
			sprite.color = Color.white;
	}

	public void OnMouseDown(){
		this.transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp(){

		this.transform.localScale = Vector3.one;

		if (targetObject != null) {
			targetObject.SendMessage (targetMessage);
		}
	}
}
