using UnityEngine;
using System.Collections;

public class ColliderAdjuster : MonoBehaviour {

    // Use this for initialization
    void Start() {
        CircleCollider2D collider = (CircleCollider2D)collider2D;
        collider.radius = renderer.bounds.extents.x / transform.localScale.x;

    }

    // Update is called once per frame
    void Update() {

    }
}
