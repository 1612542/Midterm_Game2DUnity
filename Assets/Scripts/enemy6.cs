using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6 : MonoBehaviour
{
	public float speed;
	public float magnitude;
	public float frequency = 0.5f;	
	Vector3 pos, scale;

    void Start()
    {
        speed = Random.Range(0.1f, 0.6f);
        magnitude = Random.Range(0.1f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
  	    Move();
    }

    void Move()
    {
	    pos -= transform.right*Time.deltaTime*speed;
	    transform.position = pos + transform.up *Mathf.Sin(Time.time*frequency) *magnitude;
    }
}
