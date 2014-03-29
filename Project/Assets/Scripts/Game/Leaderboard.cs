using UnityEngine;
using System.Collections;
using SimpleJSON;
public class Leaderboard : MonoBehaviour {

    public GUISkin skin;
    private ArrayList scoreList;
    void Start() {

        scoreList = new ArrayList();
        HighScores scores = new HighScores();
        scores.OnRequestComplete = OnRequestComplete;
        StartCoroutine(scores.GetGlobalHighScores());



    }

    void OnRequestComplete(object sender, HighscoreRequestEventArgs args) {

        JSONNode node = JSON.Parse(args.response);
        foreach (JSONNode score in node.AsArray) {
            string line = score["name"];


            string scoreString = score["score"];
            line += scoreString.PadLeft(10);
            Debug.Log(scoreString.PadLeft(10));

            scoreList.Add(line);
        }
    }

    private Vector2 scrollPosition = Vector2.zero;
    void OnGUI() {
        int lineHeight = 30;
        GUI.skin = skin;
        scrollPosition = GUI.BeginScrollView(new Rect(0, 100, Screen.width, Screen.height - 100), scrollPosition, new Rect(0, 0, Screen.width, lineHeight * scoreList.Count));
        int index = 0;
        foreach (string line in scoreList) {
            GUI.Label(new Rect(0, index * lineHeight, 300, lineHeight), line);
            index++;

        }
        GUI.EndScrollView();

    }
    // Update is called once per frame
    void Update() {

    }
}
