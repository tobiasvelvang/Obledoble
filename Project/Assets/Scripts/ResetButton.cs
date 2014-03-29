using System;
using UnityEngine;
using System.Collections;




public delegate void OnButtonClick(GameObject sender);


public class ResetButton : MonoBehaviour {


    public OnButtonClick onClick;

    void OnMouseUp() {
        onClick(this.gameObject);

    }
}
