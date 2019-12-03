using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ebullet : MonoBehaviour
{
	public Transform tf;
	public int damage = 40;
	public float speed;
	Vector3 direction;
	GameObject x;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
	    x = GameObject.FindGameObjectWithTag("MegaMan");
        sr = GetComponent<SpriteRenderer>();
	    speed = Random.Range(0.1f,2f);
        direction = x.transform.position - transform.position;
        if (direction.x>0) sr.flipX=true;
    }

    // Update is called once per frame
    void Update()
    {
     	tf.Translate(direction/direction.magnitude*Time.deltaTime*speed);
    }

    void OnBecameInvisible()
    {
  	    Destroy(gameObject);
    }
}
