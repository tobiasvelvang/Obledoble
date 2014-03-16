using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject cannonObject;
	public int shootsLeft = 3;

	TextMesh textMesh;

	Cannon cannon;

	// Use this for initialization
	void Start () {
		cannon = cannonObject.GetComponent<Cannon> ();
		cannon.onCannonFire += onFire;
		cannon.canFire = true;
		textMesh = GetComponent<TextMesh> ();
		textMesh.text = "Shots left: " + shootsLeft;
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void onFire(object sender, CannonFireEvent args){
		Debug.Log ("poop");
		args.projectile.onCollideHandler += onCollide ;
		cannon.canFire = false;
		if (shootsLeft == 0) {
						textMesh.text = "Game over";
				} else {
						shootsLeft = shootsLeft - 1;
						textMesh.text = "Shots left: " + shootsLeft;
				}


	}
	public void onCollide(object sender, ProjectileEvent args){
		GameObject other = args.other;
		if(other.layer == LayerMask.NameToLayer("circles")){
			Destroy(args.projectile.gameObject);
			cannon.canFire = true;
		}if (shootsLeft == 0) {
						cannon.canFire = false;
				}

	}

}
