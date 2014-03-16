using UnityEngine;
using System.Collections;

public class kanon : MonoBehaviour {

	public GameObject ProjectilePrefab;
	float xMouse = 0.0F;
	float yMouse = 0.0F;
	bool mousedown;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame

	void Update () {

		float zAngle = 0.0F;
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 mouseDiff = Input.mousePosition;
		xMouse = screenPos.x - mouseDiff.x;
		yMouse = screenPos.y - mouseDiff.y;

		if (yMouse < 0) {
			zAngle = - Mathf.Rad2Deg*Mathf.Atan(xMouse /yMouse);
			transform.eulerAngles = new Vector3(0, 0, zAngle);
		}
		if (Input.GetMouseButton (0)) {
			if (!mousedown)
					fire ();
			mousedown = true;
			} else {
			mousedown = false;
			}
	}
	void fire(){
		GameObject projectile = (GameObject) Instantiate (ProjectilePrefab);
		projectile.transform.position = transform.position;
		Projectile projectileScript = projectile.GetComponent < Projectile> ();
		projectileScript.Direction = -(new Vector2 (xMouse, yMouse));


	
	}

}
