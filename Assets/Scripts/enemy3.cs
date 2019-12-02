using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    Object bulletRef1;
    Object bulletRef2;
    bool cFire=true;
    bool isVisible = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletRef1 = Resources.Load("ebullet2");
        bulletRef2 = Resources.Load("ebullet");
    }
    void Update(){
        if(cFire && isVisible){
            InvokeRepeating("Fire", Random.Range(0f, 5f), Random.Range(1f, 5f));
            cFire = false;
        }
    }
    void OnBecameVisible(){
        isVisible = true;
    }


    void Fire()
    {
        GameObject x=(GameObject)Instantiate(bulletRef1, firePoint.position, firePoint.rotation);
        GameObject y=(GameObject)Instantiate(bulletRef2, firePoint2.position, firePoint2.rotation);
    }
}
