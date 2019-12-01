using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    Object bulletRef1;
    Object bulletRef2;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("MegaMan");
        bulletRef1 = Resources.Load("ebullet2");
        bulletRef2 = Resources.Load("ebullet");
        //InvokeRepeating("Fire", 1f, 4f);
        InvokeRepeating("Fire", Random.Range(0f,5f), Random.Range(1f,5f));
    }

    void Fire()
    {
        //if ((transform.position.x - 2 <= player.transform.position.x
        //    && player.transform.position.x <= transform.position.x)
        //    || (transform.position.x <=player.transform.position.x
        //    && player.transform.position.x <= transform.position.x + 1))
        //{
            GameObject x=(GameObject)Instantiate(bulletRef1, firePoint.position, firePoint.rotation);
            GameObject y=(GameObject)Instantiate(bulletRef2, firePoint2.position, firePoint2.rotation);
        //}

        //if (player.transform.position.x > transform.position.x + 1)
        //    CancelInvoke("Fire");
    }
}
