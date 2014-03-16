using UnityEngine;
using System.Collections;
using System;

public class ProjectileEvent: EventArgs{
	public Projectile projectile;
	public GameObject other;
}

public delegate void OnProjectileCollideHandler(object sender, ProjectileEvent args);

public class Projectile : MonoBehaviour {
	public Vector2 Direction;
	public float Speed;
	public GameObject PathNodePrefab;
	public float NodePlacementDistance;

	public OnProjectileCollideHandler onCollideHandler;
	private float TraveledDistance;

	void Start () {



		Direction.Normalize ();
		rigidbody2D.velocity = Direction * Speed;
	}
	

	void Update () {
		Vector2 temp = transform.position;
		Vector2 movement = Direction * Speed*Time.deltaTime;;
		temp += movement;
		TraveledDistance += movement.magnitude;
		if (TraveledDistance >= NodePlacementDistance) {
			float diff = TraveledDistance - NodePlacementDistance;
			Vector2 nodePos = transform.position - (Vector3)Direction*diff;
			PlacePathNode(nodePos);
			TraveledDistance = diff;
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("col");

			if(onCollideHandler != null)
				onCollideHandler(this, new ProjectileEvent{ projectile = this , other = col.gameObject});



	}

	void PlacePathNode(Vector2 position){
		GameObject node = (GameObject)Instantiate (PathNodePrefab);
		node.transform.position = position;
	}




}
