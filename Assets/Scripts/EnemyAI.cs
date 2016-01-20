using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> waypoints = new List<GameObject>();
    public float maxSpeed = 1f;
    public Bullet bullet;
    public float reloadTime = 2f;

    float lastShotTime;
    float speed;

    Rigidbody2D rigidbody;
    int currentWaypoint = 0;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
        lastShotTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    private void UpdateWaypoint()
    {
        Vector3 waypointVec = waypoints[currentWaypoint].transform.position - transform.position;
        if (waypointVec.magnitude < rigidbody.velocity.magnitude * Time.fixedDeltaTime)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
                currentWaypoint = 0;
        }
        else
        {
            rigidbody.velocity = waypointVec.normalized * speed;
        }
    }

    private void FireBullet(Vector3 target)
    {
        Bullet go = Instantiate(bullet,
                            transform.position + Vector3.left * 10f,
                            Quaternion.identity) as Bullet;
        go.origin = gameObject;
        go.target = player.transform.position;
    }

    void FixedUpdate()
    {
        UpdateWaypoint();
        if(Time.time - lastShotTime >= reloadTime && Physics2D.Raycast(transform.position, player.transform.position))
        {
            FireBullet(player.transform.position);
            lastShotTime = Time.time;
        }
    }


}
