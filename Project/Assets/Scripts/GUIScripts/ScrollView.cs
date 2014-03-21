using UnityEngine;
using System.Collections;

public class ScrollView : MonoBehaviour {
	public GameObject Content;
	public Vector2 Size;
	// Use this for initialization
	void Start () {
		BoxCollider2D collider = (BoxCollider2D)collider2D;
		collider.size = Size;

	
	}

	private Vector2 MousePosition;
	void BeginDrag(){
		MousePosition = Input.mousePosition;

	}

	void Dragging(){
		float changeY = (Input.mousePosition.y - MousePosition.y)*Time.deltaTime;
		MousePosition = Input.mousePosition;


		Scroll (changeY);
	}

	void Scroll(float amount){
		if (amount < 0) {
			float contentTop = Content.renderer.bounds.max.y;
			if(transform.InverseTransformPoint(new Vector2(0, contentTop)).y + amount < transform.position.y + Size.y/2.0f){
				return;
			}
		}else{
			Debug.Log(amount);
			float contentBottom = Content.renderer.bounds.min.y;
			if(transform.InverseTransformPoint(new Vector2(0, contentBottom)).y + amount > transform.position.y - Size.y/2.0f){
				return;
				
			}

		}

		Vector2 pos = Content.transform.position;
		pos.y += amount;
		Content.transform.position = pos;

	}


	void OnMouseDown(){
		BeginDrag ();
	}

	void OnMouseDrag(){
		Dragging ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
