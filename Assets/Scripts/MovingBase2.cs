﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase2 : MonoBehaviour
{
    private Vector2 startPos, endPos;
    public float speed = 0.75f;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(transform.position.x, transform.position.y - 3.6f);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == endPos.x && transform.position.y == endPos.y)
        {
            transform.position = startPos;
            endPos = new Vector2(transform.position.x, transform.position.y - 3.6f);
        }
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
}
