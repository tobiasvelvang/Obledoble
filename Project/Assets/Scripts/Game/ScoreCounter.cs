using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {


    private TextMesh Text;
    // Use this for initialization
    void Start() {
        Text = gameObject.transform.parent.GetComponentInChildren<TextMesh>();
        Text.text = "test";
    }

    public string DisplayedText {
        get { return this.Text.text; }
        set { this.Text.text = value; }

    }
    // Update is called once per frame
    void Update() {
        
    }
}
