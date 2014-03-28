using UnityEngine;
using System.Collections;

public class ScrollView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RecalculateBounds ();
	
	}

	public void RecalculateBounds(){
		Bounds bounds = new Bounds ();
		foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) {

			bounds.Encapsulate(renderer.bounds);
		}
		BoxCollider2D boxCollider = (BoxCollider2D)collider2D;
		boxCollider.size = new Vector2 (bounds.extents.x*2, bounds.extents.y*2);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
