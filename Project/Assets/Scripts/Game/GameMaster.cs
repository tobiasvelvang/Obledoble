﻿using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public int NumberOfCircles;
	public Vector2 RadiusRange;
	public GameObject cannonObject;
	public GameObject scoreTextObject;

	public float timelapsed = 0F;
	public GameObject ResetButtonPrefab;
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
	}


	public void onFire(object sender, CannonFireEvent args){
		args.projectile.OnCollide += OnCollide ;
		args.projectile.OnDirectionChange += OnProjectileDirectionChange;
		cannon.canFire = false;

		Vector2 spawnPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		spawner.SpawnCircle (0.2f, spawnPos);

	}

	public void OnProjectileDirectionChange(object sender, ProjectileDirectionChangeEvent args){
		args.projectile.Ignore = spawner.SpawnCircle (0.2f, args.projectile.transform.position);
		

	}
	public void OnCollide(object sender, ProjectileEvent args){
		GameObject other = args.other;
		if(other.layer == LayerMask.NameToLayer("circles")){
		
			Destroy(args.projectile.gameObject);
			cannon.canFire = true;
			changeScore(totalScore + timelapsed * multiplier);
			timelapsed = 0F;
			if(cannon.shootsLeft == 0){
				gamedone = true;
				GameObject resetButton = (GameObject)Instantiate(ResetButtonPrefab);
				ResetButton buttonScript = resetButton.GetComponent<ResetButton>();
				buttonScript.onClick += ResetGame;
				
			}

		
		}if (other.layer == LayerMask.NameToLayer ("walls")) {

			multiplier += 1;
		}
		if (cannon.shootsLeft == 0) {
			cannon.canFire = false;

						
		}


	}
	public string stringToEdit = "Hello World";
	void OnGUI() {
		if (gamedone) {
			stringToEdit = GUI.TextField (new Rect (33, 300, 200, 20), stringToEdit, 25);
		}
	}
	public void ResetGame(GameObject sender){

		//OnGUI ();
		Debug.Log ("ppopo");
		cannon.shootsLeft = 7;
		cannon.canFire = true;
		changeScore (0);
		Destroy (sender);
		gamedone = false;
		Application.LoadLevel ("Obledoble");


	
	}
}
