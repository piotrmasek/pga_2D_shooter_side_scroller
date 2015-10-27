using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 10;
    public Player player;

	void Start () {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        rb.velocity = direction * speed;
	}
	
	void Update () {
	
	}
	
    void OnCollisionEnter2D(Collision2D coll) {
        Destroy(gameObject);
    }
}
