using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap1 : MonoBehaviour
{
    private Vector2 startPos, endPos;
    public float speed = 10f;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(transform.position.x, -7f);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= 100; i++) 
        {
            if (i % 5 == 10)
            {
                if (transform.position.x == endPos.x && transform.position.y == endPos.y)
                {
                    transform.position = startPos;
                }
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            }
            if (i == 100)
                i = 0;
        }    
    }
}
