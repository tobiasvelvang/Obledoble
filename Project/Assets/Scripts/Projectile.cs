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
	private ArrayList nodes;
	void Start () {
		Direction.Normalize ();
		rigidbody2D.velocity = Direction * Speed;
		nodes = new ArrayList ();
	}
	

	void FixedUpdate(){
		rigidbody2D.velocity = Direction*Speed;
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
		GameObject other = col.gameObject;
		if(other.layer == LayerMask.NameToLayer("walls")){

			if(other.CompareTag("left") || other.CompareTag("right"))
				Direction.x *= -1;
			else{
				Direction.y *= -1;
			}
			rigidbody2D.velocity = Direction*Speed;
		}

		if(onCollideHandler != null)
			onCollideHandler(this, new ProjectileEvent{ projectile = this , other = col.gameObject});



	}

	void OnDestroy(){

		foreach (GameObject node in nodes)
			Destroy (node);
	}
	void PlacePathNode(Vector2 position){
		GameObject node = (GameObject)Instantiate (PathNodePrefab);
		node.transform.position = position;
		nodes.Add (node);
	}




}
