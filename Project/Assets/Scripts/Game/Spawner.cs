using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Rect Stage;
    public GameObject CirclePrefab;
    public GameObject WallPrefab;
    // Use this for initialization
    void Start() {

        GameObject left = (GameObject)Instantiate(WallPrefab);
        left.tag = "left";
        GameObject top = (GameObject)Instantiate(WallPrefab);
        top.tag = "top";
        GameObject right = (GameObject)Instantiate(WallPrefab);
        right.tag = "right";
        GameObject bottom = (GameObject)Instantiate(WallPrefab);
        bottom.tag = "bottom";

        left.transform.position = new Vector2(Stage.xMin - left.renderer.bounds.extents.x, Stage.yMax / 2);
        left.transform.localScale = new Vector2(1, Stage.yMax / (bottom.renderer.bounds.extents.y * 2));
        top.transform.position = new Vector2(Stage.xMax / 2, Stage.yMax + top.renderer.bounds.extents.x);
        top.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        top.transform.localScale = new Vector2(1, (Stage.xMax + top.renderer.bounds.extents.y * 4) / (bottom.renderer.bounds.extents.y * 2));
        right.transform.position = new Vector2(Stage.xMax + left.renderer.bounds.extents.x, Stage.yMax / 2);
        right.transform.localScale = new Vector2(1, Stage.yMax / (bottom.renderer.bounds.extents.y * 2));
        bottom.transform.position = new Vector2(Stage.xMax / 2, Stage.yMin - bottom.renderer.bounds.extents.x);
        bottom.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        bottom.transform.localScale = new Vector2(1, (Stage.xMax + bottom.renderer.bounds.extents.y * 4) / (bottom.renderer.bounds.extents.x * 2));

        float vertical = Camera.main.orthographicSize * 2.0f;
        float horizontal = vertical * Camera.main.aspect;
        float adjust = Mathf.Min(vertical - (Stage.yMax + top.renderer.bounds.extents.y * 2), horizontal - (Stage.xMax + left.renderer.bounds.extents.x * 2));

        Camera.main.orthographicSize -= adjust / 2;

        Vector3 cameraPosition = new Vector3((Stage.xMax) / 2, Stage.yMax / 2, -10);
        Camera.main.transform.position = cameraPosition;


    }

    public void SpawnCircles(int count, Vector2 radiusRange) {
        for (int i = 0; i < count; i++) {
            float radius = Random.Range(radiusRange.x, radiusRange.y);
            float x = Random.Range(Stage.xMin + radius, Stage.xMax - radius);
            float y = Random.Range(Stage.yMin + radius + 2, Stage.yMax - radius);
            SpawnCircle(radius, new Vector2(x, y));

        }
    }
    public GameObject SpawnCircle(float radius, Vector2 position) {

        GameObject circle = (GameObject)Instantiate(CirclePrefab);
        circle.transform.position = position;
        Circle script = circle.GetComponent<Circle>();
        script.Radius = radius;
        return circle;


    }


}
