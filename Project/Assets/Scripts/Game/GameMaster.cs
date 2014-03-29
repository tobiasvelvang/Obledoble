using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    public int NumberOfCircles;
    public Vector2 RadiusRange;
    public GameObject cannonObject;
    public GameObject scoreTextObject;

    public GameObject ResetButtonPrefab;
    TextMesh textMesh;
    TextMesh score;
    TextMesh RoundScoreField;
    float RoundScore;
    float TotalScore;
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
        DisplayRoundScore(0);


    }
    void DisplayRoundScore(float score) {

        RoundScoreField.text = "" + (int)score;

    }

    // Update is called once per frame
    void Update() {

        if (!(cannon.canFire) && !(gamedone)) {
            RoundScore += 10.0f * Time.deltaTime;
            Debug.Log(RoundScore);
            DisplayRoundScore(RoundScore);

        }


    }



    public void onFire(object sender, CannonFireEvent args) {
        args.projectile.OnCollide += OnCollide;
        args.projectile.OnDirectionChange += OnProjectileDirectionChange;
        cannon.canFire = false;

        Vector2 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawner.SpawnCircle(0.2f, spawnPos);

    }

    public void OnProjectileDirectionChange(object sender, ProjectileDirectionChangeEvent args) {
        args.projectile.Ignore = spawner.SpawnCircle(0.2f, args.projectile.transform.position);


    }
    public void OnCollide(object sender, ProjectileEvent args) {
        GameObject other = args.other;
        if (other.layer == LayerMask.NameToLayer("circles")) {

            Destroy(args.projectile.gameObject);
            cannon.canFire = true;
            TotalScore += RoundScore;
            RoundScore = 0;
            DisplayRoundScore(RoundScore);

            if (cannon.shootsLeft == 0) {
                gamedone = true;

                if (TotalScore > LocalHighscore.GetLocalHighScore()) {
                    LocalHighscore.SetLocalHighScore((int)TotalScore);

                }
                GameObject resetButton = (GameObject)Instantiate(ResetButtonPrefab);
                ResetButton buttonScript = resetButton.GetComponent<ResetButton>();
                buttonScript.onClick += ResetGame;

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

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(10, 5, 80, 40), "Total score \n" + (int)TotalScore);
        GUI.Label(new Rect(Screen.width - 90, 5, 80, 40), "Personal best \n" + LocalHighscore.GetLocalHighScore());
    }
    public void ResetGame(GameObject sender) {



        Debug.Log("ppopo");
        cannon.shootsLeft = 7;
        cannon.canFire = true;
        DisplayRoundScore(0);
        Destroy(sender);
        gamedone = false;
        Application.LoadLevel("Obledoble");



    }
}
