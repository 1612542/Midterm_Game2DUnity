using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4 : MonoBehaviour
{
    public Transform firePoint;
    Object bulletRef;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("MegaMan");
        bulletRef = Resources.Load("ebullet3");
        //InvokeRepeating("Fire", 2f, 5f);
        InvokeRepeating("Fire", Random.Range(0f,5f), Random.Range(1f,5f));
    }

    void Fire()
    {
        //if ((transform.position.x - 2 <= player.transform.position.x
        //    && player.transform.position.x <= transform.position.x)
        //    || (transform.position.x <= player.transform.position.x
        //    && player.transform.position.x <= transform.position.x + 1))
        //{
            GameObject bullet = (GameObject)Instantiate(bulletRef, firePoint.position, firePoint.rotation);
        //}
        //if (player.transform.position.x > transform.position.x + 1)
        //    CancelInvoke("Fire");
    }
}
