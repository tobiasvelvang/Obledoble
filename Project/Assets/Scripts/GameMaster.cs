using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject cannonObject;
	public int shootsLeft = 3;
	public int timelapsed = 0;
	TextMesh textMesh;
	TextMesh score;

	Cannon cannon;

	// Use this for initialization
	void Start () {
		cannon = cannonObject.GetComponent<Cannon> ();
		cannon.onCannonFire += onFire;
		cannon.canFire = true;
		textMesh = GetComponent<TextMesh> ();
		textMesh.text = "Shots left: " + shootsLeft + "Score: " + timelapsed/10;

	
	}
	
	// Update is called once per frame
	void Update () {
		timelapsed += 1;
		textMesh.text = "Shots left: " + shootsLeft + "Score: " + timelapsed/10;


	}
	public void onFire(object sender, CannonFireEvent args){
		Debug.Log ("poop");
		args.projectile.onCollideHandler += onCollide ;
		cannon.canFire = false;
		if (shootsLeft == 0) {
						textMesh.text = "Game over";
				} else {
						shootsLeft = shootsLeft - 1;
						textMesh.text = "Shots left: " + shootsLeft + "Score: " + timelapsed/10;
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
