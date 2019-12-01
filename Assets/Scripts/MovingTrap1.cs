﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap1 : MonoBehaviour
{
    private Vector2 startPos, endPos, nextPos;
    private float speed = 0.4f;

    void Start()
    {
        nextPos = transform.position;
        startPos = transform.position;
        endPos = new Vector2(16.78f, transform.position.y);
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