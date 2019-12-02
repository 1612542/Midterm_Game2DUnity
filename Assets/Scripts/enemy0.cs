using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy0 : MonoBehaviour
{
    public Transform firePoint;
    Object bulletRef;
    bool cFire=true;
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("ebullet1");
        
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
        GameObject bullet = (GameObject)Instantiate(bulletRef, firePoint.position, firePoint.rotation);
    }
    
}
