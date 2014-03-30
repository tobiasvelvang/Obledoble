using System;
using UnityEngine;
using System.Collections;




public delegate void OnButtonClick();


public class EndOfGameMenuScript : MonoBehaviour {
	public Texture2D redBubble;
	public Texture2D restart;
	public Texture2D submit;


	public GUISkin restartSkin;
	public OnButtonClick onClick;
	public string textFieldString = "text field";
	void OnGUI () {

		GUI.skin = restartSkin;


		GUI.Box(new Rect(16,110,270,200), redBubble);
		
		GUI.TextField (new Rect (16, 210, 180, 50), textFieldString);
		if(GUI.Button(new Rect(195,210,90,50), submit)) {
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(16,260,270,50), restart)) {
			Application.LoadLevel(1);
		}
		}
	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
	}
	void OnMouseUp(){
		onClick();


    }
}
