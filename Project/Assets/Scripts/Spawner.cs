using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public int NumberOfCircles;
	public Vector2 RadiusRange;
	public Rect Stage;
	public GameObject CirclePrefab;
	public GameObject WallPrefab;
	// Use this for initialization
	void Start () {
		SpawnCircles (NumberOfCircles, RadiusRange, Stage);
		GameObject left = (GameObject)Instantiate (WallPrefab);
		GameObject top = (GameObject)Instantiate (WallPrefab);
		GameObject right = (GameObject)Instantiate (WallPrefab);
		GameObject bottom = (GameObject)Instantiate (WallPrefab);

		left.transform.position = new Vector2 (Stage.xMin - left.renderer.bounds.extents.x, Stage.yMax / 2);
		left.transform.localScale = new Vector2 ( 1, Stage.yMax/(bottom.renderer.bounds.extents.y * 2));
		top.transform.position = new Vector2 (Stage.xMax / 2, Stage.yMax + top.renderer.bounds.extents.x);
		top.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 90));
		top.transform.localScale = new Vector2 ( 1, (Stage.xMax + top.renderer.bounds.extents.y*4)/(bottom.renderer.bounds.extents.y * 2));
		right.transform.position = new Vector2 (Stage.xMax + left.renderer.bounds.extents.x, Stage.yMax / 2);
		right.transform.localScale = new Vector2 (1, Stage.yMax / (bottom.renderer.bounds.extents.y * 2));
		bottom.transform.position = new Vector2 (Stage.xMax / 2, Stage.yMin - bottom.renderer.bounds.extents.x);
		bottom.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 90));
		bottom.transform.localScale = new Vector2 ( 1, (Stage.xMax + bottom.renderer.bounds.extents.y*4)/(bottom.renderer.bounds.extents.x * 2));

		float vertical = Camera.main.orthographicSize * 2.0f;
		float horizontal = vertical * Camera.main.aspect;
		float adjust = Mathf.Min (vertical-(Stage.yMax + top.renderer.bounds.extents.y*2), horizontal - (Stage.xMax + left.renderer.bounds.extents.x*2));

		Camera.main.orthographicSize -= adjust/2;
		Debug.Log (vertical);
		Debug.Log (horizontal);
		Debug.Log (adjust);

		Vector3 cameraPosition = new Vector3 ((Stage.xMax) / 2, Stage.yMax / 2,-10);
		Camera.main.transform.position = cameraPosition;


	}

	void SpawnCircles (int count, Vector2 radiusRange, Rect stage){
		for (int i = 0; i< count; i++) {
			float radius = Random.Range(radiusRange.x, radiusRange.y);
			float x = Random.Range(stage.xMin + radius, stage.xMax -radius);
			float y = Random.Range(stage.yMin + radius, stage.yMax - radius);
			SpawnCircle(radius, new Vector2(x,y));

		}
	}
	void SpawnCircle(float radius, Vector2 position){

		GameObject circle = (GameObject)Instantiate (CirclePrefab);
		circle.transform.position = position;
		Circle script = circle.GetComponent<Circle> ();
		script.Radius = radius;



	}


}
