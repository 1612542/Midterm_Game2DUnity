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
    // Start is called before the first frame update
    void Start()
    {
	x= GameObject.Find("x");
	speed =Random.Range(0.1f,2f);
        direction = x.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     	tf.Translate(direction/direction.magnitude*Time.deltaTime*speed);
    }
    void OnBecameInvisible() {
  	Destroy(gameObject);
    }
}
