using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4 : MonoBehaviour
{
    public Transform firePoint;
    Object bulletRef;

    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("ebullet3");
        InvokeRepeating("Fire", Random.Range(0f,5f), Random.Range(1f,5f));
    }

    void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletRef, firePoint.position, firePoint.rotation);
    }
}
