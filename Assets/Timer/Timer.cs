using UnityEngine;
using System.Collections;
using System.Timers;

public class Timer : MonoBehaviour {

    private System.Timers.Timer time;

	private MemoryCard card = null;

	// Use this for initialization
	public void Start () {
		
        time = new System.Timers.Timer();
		time.Elapsed += Time_Elapsed;
	}

	void Time_Elapsed (object sender, ElapsedEventArgs e)
	{

		time.Enabled = false;

		StopAnimation ();


	}


    // Update is called once per frame
	void Update () {

		if (time.Enabled) {

			card.transform.Rotate (0.0f, -5.0f, 0.0f);

			card.CardFlips (card.transform.rotation.eulerAngles.y);
		}
	
	}

	private void StopAnimation(){

		card.FlipFaceUp();

		card = null;
	}

    public void SetTimeLimit() {
		time.Interval = 4250;
    }

    public bool Enable {
        get { return time.Enabled; }
        set { time.Enabled = value; }
    }

	public void SetCard(MemoryCard card){
		this.card = card;
	}
}