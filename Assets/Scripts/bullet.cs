﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	public Rigidbody2D rb;
	public int damage = 80;

    // Start is called before the first frame update
    void Start()
    {
	    rb.velocity = transform.right * 5f;
	   
    }

    void OnTriggerEnter2D(Collider2D col)
    {
	    if (col.gameObject.tag!= "ebullet") Destroy(gameObject);
	    Enemy enemy = col.GetComponent<Enemy>();
	    if (enemy != null) enemy.TakeDamage(damage);
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
