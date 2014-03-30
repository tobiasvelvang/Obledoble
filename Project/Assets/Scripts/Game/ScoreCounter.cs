using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {


    private TextMesh Text;
    // Use this for initialization
    
    void Start() {
        Text = gameObject.transform.parent.GetComponentInChildren<TextMesh>();
        Debug.Log(Text);
    }

    public string DisplayedText {
        get { return this.Text.text; }
        set { this.Text.text = value;}

    }

    public void BeginAnimating() {
        StartCoroutine(Scale());

    }

    private IEnumerator Scale() {
        Vector3 temp = transform.parent.transform.localScale;;
        int iterations = 2;
        float amount =0.1f;
        float waitTime = 1.0f / 30.0f; ;
        for (int i = 0; i < iterations; i++) {
            
            temp.x += amount;
            temp.y += amount;

            transform.parent.transform.localScale = temp;
           
            yield return new WaitForSeconds(waitTime);
            Debug.Log(i);
        }
        Debug.Log("done");
        for (int i = 0; i < iterations; i++) {
            Debug.Log("shrink");
 
            temp.x -= amount;
            temp.y -= amount;
            transform.parent.transform.localScale = temp;
            yield return new WaitForSeconds(waitTime);
        }
       
    }

 

    // Update is called once per frame
    void Update() {
        
    }
}
