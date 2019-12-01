using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6 : MonoBehaviour
{
	public float speed;
	public float magnitude;
	public float frequency = 0.5f;	
	Vector3 pos, scale;
    //private Vector2 startPos, endPos;
    //private int count = 0;

    void Start()
    {
        speed = Random.Range(0.1f, 0.6f);
        magnitude = Random.Range(0.1f, 0.6f);
        //speed = Random.Range(0.6f, 0.8f);
        //magnitude = Random.Range(0.1f, 0.6f);
        //pos = transform.position;

        //startPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
  	    Move();
        //if (transform.position.x == startPos.x + Random.Range(5f, 7f) 
        //    && transform.position.y == startPos.y + Random.Range(5f, 7f) || count == 200)
        //{
        //    transform.position = startPos;
        //    pos = startPos;
        //    count = 0;
        //}
    }

    void Move()
    {
	    pos -= transform.right*Time.deltaTime*speed;
	    transform.position = pos + transform.up *Mathf.Sin(Time.time*frequency) *magnitude;
        //count++;
    }
}
