﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap2 : MonoBehaviour
{
    public Vector2 startPos, endPos, nextPos;
    public float speed = 0.4f;

    void Start()
    {
        nextPos = transform.position;
        startPos = transform.position;
        endPos = new Vector2(transform.position.x - 10.8f, transform.position.y);
    }

    void Update()
    {
        if (transform.position.x == startPos.x && transform.position.y == startPos.y)
        {
            nextPos = endPos;
        }
        if (transform.position.x == endPos.x && transform.position.y == endPos.y)
        {
            nextPos = startPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
