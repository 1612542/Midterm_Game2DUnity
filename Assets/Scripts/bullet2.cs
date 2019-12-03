using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
	public Rigidbody2D rb;
	public int damage = 150;

    // Start is called before the first frame update
    void Start()
    {
	    rb.velocity = transform.right * 5f;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
	    Enemy enemy = col.GetComponent<Enemy>();
	    if (enemy != null) enemy.TakeDamage(damage);
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}