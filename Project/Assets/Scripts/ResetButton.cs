using System;
using UnityEngine;
using System.Collections;




public delegate void OnButtonClick(GameObject sender);


public class ResetButton : MonoBehaviour {
	public Texture2D redBubble;


	public GUISkin restartSkin;
	public OnButtonClick onClick;
	private Rect windowRect = new Rect (30, 170, 200, 200);
	void OnGUI () {

		GUI.skin = restartSkin;
		windowRect = GUI.Window (0, windowRect, WindowFunction, redBubble);

		}
	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
	}
	void OnMouseUp(){
		onClick(this.gameObject);


    }
}
