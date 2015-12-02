using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public bool lockScreen = false;
    public GameObject bullet;
    
    public int score = 0;
    public int health = 5;
    public int maxHealth = 5;
    private Text scoreText;
    private Text livesText;
    private Image hpBar;

    // Use this for initialization
    void Start ()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        hpBar = GameObject.Find("PlayerHpBar").GetComponent<Image>();
        Debug.Assert(livesText && scoreText && hpBar);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1")) {
            GameObject go = Instantiate(bullet, 
                                transform.position,
                                Quaternion.identity) as GameObject;
            go.GetComponent<Bullet>().player = this;
        }

        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + health.ToString() + "/" + maxHealth;
        UpdateHpBar();


    }

    private void UpdateHpBar()
    {
        if((float)health/maxHealth > 0.2)
        {
            hpBar.color = Color.green;
        }
        else
        {
            hpBar.color = Color.red;
        }
        hpBar.rectTransform.localScale = new Vector3((float)health / maxHealth, 1, 1);

    }

    public void TakeHealth(int hp_to_take)
    {
        health -= hp_to_take;
        

        if (health <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
        health = 5;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroyable obj = collision.gameObject.GetComponent<Destroyable>();
        if (obj)
        {
            TakeHealth(1);
        }
    }
}
