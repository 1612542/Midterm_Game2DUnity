﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 200;
	Object explosionRef;
	Object hitRef;

    void Start(){
	    explosionRef = Resources.Load("explosion1"); 
	    hitRef = Resources.Load("hit");
        if (tag == "bees" || tag == "mushroom")
            health = 150;
        else if (tag == "flying_face" || tag == "bats")
            health = 200;
        else if (tag == "bosscar")
            health = 500;
    }


    public void TakeDamage(int damage)
    {
     	health -= damage;
	    GameObject hit = (GameObject)Instantiate(hitRef, transform.position, transform.rotation);
	    if (health <= 0) Die();   
    }

    void Die()
    {
	    GameObject explosion = (GameObject)Instantiate(explosionRef, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
