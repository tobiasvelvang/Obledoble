using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {
    public float Radius;
    public float AnimationSpeed;
    private ColliderAdjuster adjuster;
    void Start() {
        Vector2 scale = transform.localScale;
        scale.x = 0;
        scale.y = 0;
        this.transform.localScale = scale;
        ((CircleCollider2D)collider2D).radius = Radius * 2;
        Color temp = this.renderer.material.color;
        temp.a = 0.5f;
        adjuster = gameObject.GetComponent<ColliderAdjuster>();
       

    }



    void Update() {
        if (renderer.bounds.extents.x < Radius) {
            Vector2 temp = transform.localScale;
            temp.x += AnimationSpeed * Time.deltaTime;
            temp.y += AnimationSpeed * Time.deltaTime;
            transform.localScale = temp;
            ((CircleCollider2D)collider2D).radius = renderer.bounds.extents.x / transform.localScale.x;
            adjuster.Adjust();
        }

    }
}
