using UnityEngine;
using System.Collections;


public class ShootsLeft : MonoBehaviour {
	public GameObject Cannon;
	private Cannon cannonScript;
	private Projectile currentProjectile;
	TextMesh shootsLeftText;
	int shootsLeft = 3;

	public Vector2 pos;
	public float i;
	// Use this for initialization
	void Start () {

		shootsLeftText = GetComponent<TextMesh> ();
		shootsLeftText.text = "  3 BALLS LEFT";
		Vector2 pos = transform.position;
		float i = 0F;
		cannonScript = Cannon.GetComponent<Cannon> ();
		cannonScript.onCannonFire += onCanonFire;

	}
	
	// Update is called once per frame
	void Update () {


	}
	public void onCanonFire(object sender, CannonFireEvent args){
		Projectile projectile = args.projectile;

		projectile.onCollideHandler += textFloatIn;
	
		}
	public void textFloatIn(object sender, ProjectileEvent args){
		if(!(args.other.layer == LayerMask.NameToLayer("circles"))) return;
		Debug.Log ("CheeseFuck");
		pos.y = 0;
		transform.position = pos;


		StartCoroutine ("fadeIn");
				}

	IEnumerator fadeIn(){
		shootsLeft -= 1;
		if (shootsLeft == 1) {
						shootsLeftText.text ="  " + shootsLeft + " BALL LEFT!";
				} else {
						shootsLeftText.text ="  " + shootsLeft + " BALLS LEFT!";
				}
		Color fadeColor;
		fadeColor = renderer.material.color;
		for (float i = 0F; i < 8.0F; i += 0.1F) {

			fadeColor.a = (8.0F - i)/8.0F;
			renderer.material.color = fadeColor;
			pos.y = i;
			transform.position = pos; 
			yield return new WaitForEndOfFrame();
			//yield return new WaitForSeconds(0.1F);
		}
		}

}
