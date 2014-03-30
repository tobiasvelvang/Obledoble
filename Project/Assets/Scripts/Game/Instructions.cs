using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void OnGUI () {
		string instructionText = "Noe!";

		instructionText = GUI.TextArea(new Rect(10,10,200,100),instructionText, 200);
	}


}
