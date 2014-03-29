using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {


    void Start() {

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 extents = renderer.bounds.extents;
        if (transform.rotation.z > 0.5) {
            collider.size = new Vector2(extents.y, extents.x);
        }
        else {
            collider.size = new Vector2(extents.x, extents.y);
        }



    }


    void Update() {

    }
}
