using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Vector2 Direction;
	public float Speed;
	public GameObject PathNodePrefab;
	public float NodePlacementDistance;
	private float TraveledDistance;
	// Use this for initialization
	void Start () {
		Direction.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 temp = transform.position;
		Vector2 movement = Direction * Speed*Time.deltaTime;;
		temp += movement;
		transform.position = temp;
		TraveledDistance += movement.magnitude;
		if (TraveledDistance >= NodePlacementDistance) {
			float diff = TraveledDistance - NodePlacementDistance;
			Vector2 nodePos = transform.position - (Vector3)Direction*diff;
			PlacePathNode(nodePos);
			TraveledDistance = diff;
		}

	}

	void PlacePathNode(Vector2 position){
		GameObject node = (GameObject)Instantiate (PathNodePrefab);
		node.transform.position = position;
	}


}
