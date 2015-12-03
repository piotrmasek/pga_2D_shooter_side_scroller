using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destroyable : MonoBehaviour {

    public int health = 2;
    public SpriteRenderer sp;
    public Status playerStatus;
    public Vector3 uiOffset = Vector3.zero;
    private Text hpText;

    void Start()
    {
        GameObject prefab = Resources.Load("EnemyHpText", typeof(GameObject)) as GameObject;
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        
        hpText = Instantiate(prefab).GetComponent<Text>();
        hpText.transform.SetParent(canvas.transform);

        uiOffset.y = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        uiOffset.y += hpText.rectTransform.rect.height * 1.2f;
        

    }

    void Update()
    {
        UpdateUI();

        if (health <= 0)
            Die();
    }

    void UpdateUI()
    {
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        hpText.transform.position = cam.WorldToScreenPoint(transform.position) + uiOffset;
        hpText.text = health.ToString();
    }

    public void Die()
    {
        Destroy(gameObject);
        Destroy(hpText.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        //Player player = coll.collider.GetComponent<Player>(); // NIE STRZELA 
        Bullet bullet = coll.collider.GetComponent<Bullet>() as Bullet; // STRZELA

        //if(player != null) { // NIE STRZELA
            //Destroy(gameObject);
            //player.score++;
        //}

        if(bullet != null)
        {
            bullet.player.score++;

            health--;
                 
        }
    }
}
