using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;
public class HighscoreRequestEventArgs : EventArgs {
    public string response;
    public bool error;
}
public delegate void RequestFinishedEvent(object sender, HighscoreRequestEventArgs args);

public class HighScores {
    private const string highscoreURL = "http://piscores.no-ip.org/doblescore.php?count=100";
    private const string postScoreURL = "http://piscores.no-ip.org/doblescore.php";
    private const string secret = "8bb3cdf465001bc0ab";
    private const string localKey = "highscore";

    public RequestFinishedEvent OnRequestComplete;

    public IEnumerator GetGlobalHighScores() {
        WWW request = new WWW(highscoreURL);
        yield return request;

        HighscoreRequestEventArgs args = new HighscoreRequestEventArgs();
        if (request.error != null) {

            args.error = true;
        }
        else {
            args.response = request.text;
        }

        if (OnRequestComplete != null)
            OnRequestComplete(this, args);

    }

    public void SetLocalHighScore(int score) {
        PlayerPrefs.SetInt(localKey, score);

    }

    public int GetLocalHighScore() {
        return PlayerPrefs.GetInt(localKey);
    }
    public IEnumerator PostScore(string name, int score) {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("score", score);
        Debug.Log(name + score + secret);
        form.AddField("hash", Util.SHA1Sum(name + score + secret));
        WWW request = new WWW(postScoreURL, form.data);
        yield return request;

        if (OnRequestComplete != null)
            OnRequestComplete(this, new HighscoreRequestEventArgs() { error = request.error != null, response = request.text });


    }



}
