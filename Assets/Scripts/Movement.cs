using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject player;
    public float speed = 1;
    public float force = 10; 
    public Rigidbody2D rb;
    public Animator m_Animator;

    public bool grounded = false;
    public bool facingRight = true;
    
	// Use this for initialization
	void Start ()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }

	void FixedUpdate ()
    {
        m_Animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButton("Horizontal"))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, rb.velocity.y);

            if(Input.GetAxis("Horizontal") >= 0)
            {
                if (!facingRight)
                    Flip();
            }
            else
            {
                if (facingRight)
                    Flip();
            }
        }

        if(Input.GetButton("Jump") && grounded) {
            rb.AddForce(new Vector2(0, Input.GetAxis("Jump")*force*Time.fixedDeltaTime));
        }
	}

    //TODO: Fix colliders
    void OnTriggerEnter2D(Collider2D other)
    {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector2 local_scale = transform.localScale;
        local_scale.x *= -1;
        transform.localScale = local_scale;
    }
}
