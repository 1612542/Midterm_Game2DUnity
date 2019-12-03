using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 200;
	Object explosionRef;
	Object hitRef;
    Object hpRef;
    Object mpRef;

    void Start(){
	    explosionRef = Resources.Load("explosion1"); 
	    hitRef = Resources.Load("hit");
        hpRef = Resources.Load("healthItem");
        mpRef = Resources.Load("manaItem");
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
        int x =Random.Range(0,10);
        if (x%2==0){
            GameObject t = (GameObject)Instantiate(hpRef, transform.position, transform.rotation);
        }
        else {
            GameObject t =(GameObject)Instantiate(mpRef, transform.position, transform.rotation);
        }
            
        Destroy(gameObject);
    }
}
