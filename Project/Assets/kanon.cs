using UnityEngine;
using System.Collections;

public class kanon : MonoBehaviour {
	public float xMouse = 0.0F;
	public float yMouse = 0.0F;
	public float zAngle = 0.0F;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 mouseDiff = Input.mousePosition;
		xMouse = screenPos.x - mouseDiff.x;
		yMouse = screenPos.y - mouseDiff.y;

		if (yMouse < 0) {
			zAngle = - Mathf.Rad2Deg*Mathf.Atan(xMouse /yMouse);
			transform.eulerAngles = new Vector3(0, 0, zAngle);
				}
	}
}
