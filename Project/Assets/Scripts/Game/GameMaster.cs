using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    public int NumberOfCircles;
    public Vector2 RadiusRange;
    public GameObject cannonObject;
    public GameObject scoreTextObject;
    public GameObject ResetButtonPrefab;
    private ScoreCounter TotalScoreField;
    public GameObject TotalScoreObject {
        set { this.TotalScoreField = ((GameObject)value).GetComponentInChildren<ScoreCounter>(); }

    }
    TextMesh textMesh;
    TextMesh score;
    TextMesh RoundScoreField;
    float RoundScore;
    float TotalScore;
    int multiplier;
    private Spawner spawner;
    public bool gamedone;

    private HighScores LocalHighscore = new HighScores();
    Cannon cannon;

    // Use this for initialization
    void Start() {

        cannon = cannonObject.GetComponent<Cannon>();
        cannon.onCannonFire += onFire;
        cannon.canFire = true;


        spawner = GetComponent<Spawner>();
        spawner.SpawnCircles(NumberOfCircles, RadiusRange);
        RoundScoreField = scoreTextObject.GetComponent<TextMesh>();

        cannon.shootsLeft = 7;
        cannon.canFire = true;
        DisplayRoundScore(0, multiplier);
        gamedone = false;

        spawner.SpawnCircle(0.5f, new Vector2(spawner.Stage.xMax - 0.1f, spawner.Stage.yMin + 0.2f));
        spawner.SpawnCircle(0.06f, new Vector2(spawner.Stage.xMax / 2, spawner.Stage.yMax));

    }
    void DisplayRoundScore(float score, int multiplier) {

        RoundScoreField.text = "" + (int)score + "x" + multiplier;

    }

    // Update is called once per frame
    void Update() {

        if (!(cannon.canFire) && !(gamedone)) {
            RoundScore += 10.0f * Time.deltaTime;
            DisplayRoundScore(RoundScore, multiplier);

        }


    }



    public void onFire(object sender, CannonFireEvent args) {
        args.projectile.OnCollide += OnCollide;
        args.projectile.OnDirectionChange += OnProjectileDirectionChange;
        cannon.canFire = false;

      
    }

    public void OnProjectileDirectionChange(object sender, ProjectileDirectionChangeEvent args) {
        args.projectile.Ignore = spawner.SpawnCircle(0.2f, args.projectile.transform.position);


    }
    public void OnCollide(object sender, ProjectileEvent args) {
        GameObject other = args.other;
        if (other.layer == LayerMask.NameToLayer("circles")) {
            Destroy(args.projectile.gameObject);
            cannon.canFire = true;
            TotalScore += RoundScore*multiplier;
            RoundScore = 0;
            multiplier = 1;
            DisplayRoundScore(RoundScore, multiplier);
            TotalScoreField.DisplayedText = "" + TotalScore;
            if (cannon.shootsLeft == 0) {
                gamedone = true;

                if (TotalScore > LocalHighscore.GetLocalHighScore()) {
                    LocalHighscore.SetLocalHighScore((int)TotalScore);

                }
              

            }


        }
        else {
            if(other.layer == LayerMask.NameToLayer("walls")){
                multiplier += 1;

            }
        } 
        if (cannon.shootsLeft == 0) {
            cannon.canFire = false;

        }


    }
    public string stringToEdit = "Hello World";
    void OnGUI() {
        if (gamedone) {
            stringToEdit = GUI.TextField(new Rect(33, 300, 200, 20), stringToEdit, 25);
        }

    }
    public void ResetGame() {
        Application.LoadLevel("Obledoble");
    }

   
}
