using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public int NumberOfCircles;
	public Vector2 RadiusRange;
	public Rect Stage;
	public GameObject CirclePrefab;
	// Use this for initialization
	void Start () {
		SpawnCircles (NumberOfCircles, RadiusRange, Stage);
		/*float vertical = Camera.main.orthographicSize * 2.0f;
		float horizontal = vertical * Camera.main.aspect;
		float adjust = Mathf.Min (vertical-Stage.yMax, horizontal - Stage.xMax);
		if (adjust > 0) {
			Camera.main.orthographicSize -= adjust;
		}else{
			Debug.Log("neg");
			Camera.main.orthographicSize -= adjust;
		}
		Debug.Log (vertical);
		Debug.Log (horizontal);
		Debug.Log (adjust);

		Vector3 cameraPosition = new Vector3 (Stage.xMax / 2, Stage.yMax / 2,-10);

		Camera.main.transform.position = cameraPosition;*/


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
