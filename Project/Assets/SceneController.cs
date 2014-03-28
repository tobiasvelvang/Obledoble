using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android)	
		{	
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}

}
