using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject cannonObject;
	Cannon cannon;

	// Use this for initialization
	void Start () {
		cannon = cannonObject.GetComponent<Cannon> ();
		cannon.onCannonFire += onFire;
		cannon.canFire = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onFire(object sender, CannonFireEvent args){
		Debug.Log ("poop");
		args.projectile.onCollideHandler += onCollide ;
		cannon.canFire = false;
	}
	public void onCollide(object sender, ProjectileEvent args){
		GameObject other = args.other;
		if(other.layer == LayerMask.NameToLayer("circles")){
			Destroy(args.projectile.gameObject);
			cannon.canFire = true;
		}

	}

}
