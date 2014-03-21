using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;
public class HighscoreRequestEventArgs: EventArgs{
	public JSONNode response;
	public bool error;
}
public delegate void  RequestFinishedEvent(object sender, HighscoreRequestEventArgs args);

public class HighScores {
	private const string highscoreURL = "http://piscores.no-ip.org/doblescore.php?count=100";
	public RequestFinishedEvent OnRequestComplete;
	public IEnumerator GetGlobalHighScores(){
		WWW request = new WWW (highscoreURL);
		yield return request;
		
		HighscoreRequestEventArgs args = new HighscoreRequestEventArgs ();
		if (request.error != null) {
			args.error = true;
		} else {
			args.response = JSON.Parse(request.text);
		}
		
		if (OnRequestComplete != null)
			OnRequestComplete (this, args);
		
	}
	

	


}
