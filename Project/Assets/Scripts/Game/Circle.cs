using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {
    public float Radius;
    public float AnimationSpeed;
    private float TargetScale;
    private ColliderAdjuster adjuster;
    void Start() {
        TargetScale = Radius/renderer.bounds.extents.x;
        Vector2 scale = transform.localScale;
        scale.x = 0;
        scale.y = 0;
        this.transform.localScale = scale;
       
        adjuster = gameObject.GetComponent<ColliderAdjuster>();
        StartCoroutine(ScaleUp());
    }


    IEnumerator ScaleUp() {
        CircleCollider2D collider = (CircleCollider2D)collider2D;
        while (renderer.bounds.extents.x < Radius) {
            Vector2 temp = transform.localScale;
            temp.x += AnimationSpeed * Time.deltaTime;
            temp.y += AnimationSpeed * Time.deltaTime;
            transform.localScale = temp;
            collider.radius = renderer.bounds.extents.x / transform.localScale.x;
            adjuster.Adjust();
            yield return new WaitForEndOfFrame();
        }
        Vector2 finalScale = transform.localScale;
        finalScale.x = TargetScale;
        finalScale.y = TargetScale;
        transform.localScale = finalScale;
        
      
    }
    void Update() {
        

    }
}
