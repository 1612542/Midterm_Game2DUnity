using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ebullet3 : MonoBehaviour
{
	public Rigidbody2D rb;
	public int damage = 40;
    // Start is called before the first frame update
    void Start()
    {
	    rb.velocity = -transform.right * 5f;
	    Invoke("DestroyS", 2f);
    }

    void DestroyS()
    {
	    Destroy(gameObject);
    }
}
