using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MegaMan");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - 2 <= player.transform.position.x
            && player.transform.position.x <= transform.position.x)
        {
            BeeMoving();
        }
    }

    void BeeMoving()
    {
        Vector3 pos1 = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, pos1, 2f);
        Vector3 pos2 = new Vector3(-100, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, pos1, 5f);
    }
}
