﻿using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

    public int life = 2;
    public SpriteRenderer sp;
    public Status playerStatus;

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

            life--;
            if(life <= 0)
                Destroy(gameObject);   
        }
    }
}
