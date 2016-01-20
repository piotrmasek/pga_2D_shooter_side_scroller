using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 10;
    public float range = 250;
    public Vector3 target;
    public GameObject origin;


	void Start () {
        
	}
	
	void Update ()
    {
	  
	}

    void FixedUpdate()
    {
        if ((origin.transform.position - transform.position).magnitude > range)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = target - transform.position;      
        rb.velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject == origin)
            return;

        Player player = coll.gameObject.GetComponent<Player>();
        if (player)
        {
            player.TakeHealth(1);
        }

        Destroy(gameObject);
    }
}
