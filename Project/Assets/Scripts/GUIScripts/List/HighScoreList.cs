using UnityEngine;
using System.Collections;
using SimpleJSON;
public class HighScoreList : TextList  {

	// Use this for initialization
	void Start () {
		init ();
	}
	public void init(){
		base.init ();
		///HighScores scores = new HighScores ();
		//scores.OnRequestComplete += OnRequestComplete;
		//StartCoroutine (scores.GetGlobalHighScores());
		ListModedl<string> model = GetModel ();
		for (int i = 0; i < 100; i++) {
			model.add("Eirik\t\t\t" + (100- i));
		}

	}

	public void OnRequestComplete(object sender, HighscoreRequestEventArgs args){

		JSONNode json = args.response;
		ListModedl<string> model = GetModel ();

		foreach (JSONNode node in json.Childs) {
			string line = node["name"].ToString().PadRight(20)   + node["score"];
		
			model.add(line);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
