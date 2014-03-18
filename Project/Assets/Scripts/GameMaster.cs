using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public int NumberOfCircles;
	public Vector2 RadiusRange;
	public GameObject cannonObject;
	public GameObject scoreTextObject;

	public int shootsLeft = 3;
	public float timelapsed = 0F;
	TextMesh textMesh;
	TextMesh score;
	TextMesh totalScoreField;
	float totalScore;
	public int multiplier = 1;
	private Spawner spawner;
	public bool gamedone;


	Cannon cannon;

	// Use this for initialization
	void Start () {
		cannon = cannonObject.GetComponent<Cannon> ();
		cannon.onCannonFire += onFire;
		cannon.canFire = true;
	
		spawner = GetComponent<Spawner> ();
		spawner.SpawnCircles (NumberOfCircles, RadiusRange);
		textMesh = GetComponent<TextMesh> ();
		textMesh.text = "Shots left: " + shootsLeft + "Score: " + (int)timelapsed + "X" + multiplier;
		totalScoreField = scoreTextObject.GetComponent<TextMesh> ();
		changeScore (0);
	
	}
	void changeScore(float newScore){
		totalScore = newScore;
		totalScoreField.text = "" + (int)totalScore;

		}
	
	// Update is called once per frame
	void Update () {

		if (!(cannon.canFire) && !(gamedone)) {
			timelapsed += Time.deltaTime*10;

				}
		if (shootsLeft == 0) {
						
				} else {
						textMesh.text = "Shots left: " + shootsLeft + "Score: " + (int)timelapsed + "*" + multiplier;
				}

	}
	public void onFire(object sender, CannonFireEvent args){
		Debug.Log ("poop");
		args.projectile.onCollideHandler += onCollide ;
		cannon.canFire = false;
		if (shootsLeft == 0) {
						
				} else {
						shootsLeft = shootsLeft - 1;
			textMesh.text = "Shots left: " + shootsLeft + "Score: " + (int)timelapsed + "*" + multiplier;
		}


	}
	public void onCollide(object sender, ProjectileEvent args){
		GameObject other = args.other;
		if(other.layer == LayerMask.NameToLayer("circles")){
			ArrayList path = args.projectile.GetPath();
			if(path.Count > 5){
			
			}
			Destroy(args.projectile.gameObject);
			cannon.canFire = true;
			changeScore(totalScore + timelapsed * multiplier);
			timelapsed = 0F;
			multiplier = 0;
			if(shootsLeft == 0){
				gamedone = true;
			}

		
		}if (other.layer == LayerMask.NameToLayer ("walls")) {
				multiplier += 1;
			}
		if (shootsLeft == 0) {
				cannon.canFire = false;
						
		}

	}

}
