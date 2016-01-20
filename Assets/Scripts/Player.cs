using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : Singleton<Player>
{

    public bool lockScreen = false;
    public GameObject bullet;
    
    public int score = 0;
    public float health = 5;
    public float maxHealth = 5;
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
	    if(Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(bullet, 
                                transform.position,
                                Quaternion.identity) as GameObject;
            go.GetComponent<Bullet>().origin = gameObject;
            go.GetComponent<Bullet>().target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

       // scoreText.text = "Score: " + score.ToString();
      //  livesText.text = "Lives: " + health.ToString() + "/" + maxHealth;

       // UpdateHpBar();
        if (health <= 0)
        {
            Die();
        }


    }

    void OnLevelWasLoaded(int level)
    {
        if(level > 0)
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

            if (spawnPoint)
                Debug.Log("spawnPoint initialized!");
        }
    }

    private void UpdateHpBar()
    {
        float ratio = health / maxHealth;
        hpBar.color = new Color(1 - ratio, ratio, 0);

        hpBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

    }

    public void TakeHealth(int hp_to_take)
    {
        health -= hp_to_take;
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.c)
        
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
