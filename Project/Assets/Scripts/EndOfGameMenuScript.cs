using System;
using UnityEngine;
using System.Collections;




public delegate void OnButtonClick();


public class EndOfGameMenuScript : MonoBehaviour {
	public Texture2D redBubble;
	public Texture2D restart;
	public Texture2D submit;
	public int Score;
	public HighScores highScore;

	public GUISkin restartSkin;
	public OnButtonClick onClick;
	public string playerName = "";
	public int width = Screen.width/90;
	public int height = Screen.height/90;
	void OnGUI () {

		GUI.skin = restartSkin;


		GUI.Box(new Rect(30*width,90*width,300*width,170*width), redBubble);
		GUI.Label (new Rect (30*width, 130*width, 190*width, 40*width), "" + Score);
		playerName = GUI.TextField(new Rect(30*width, 180*width, 220*width, 40*width), playerName, 25);
		//GUI.TextField (new Rect (16, 210, 180, 50), textFieldString);
		if(GUI.Button(new Rect(249*width,180*width,80*width,40*width), submit)) {
			highScore = new HighScores ();
			highScore.OnRequestComplete += onHighScore;
			
			
			StartCoroutine (highScore.PostScore (this.playerName, this.Score));

		}
		if(GUI.Button(new Rect(30*width,220*width,300*width,40*width), restart)) {
			Application.LoadLevel(1);
		}
		}
	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
	}
	void OnMouseUp(){
		if (onClick != null) {
			onClick();
				}




    }

	void OnStart(){

	}

	public void onHighScore(object sender, HighscoreRequestEventArgs args){
		if (args.error) {
			Debug.Log ("args.error, no internet");
		}
	}
}
