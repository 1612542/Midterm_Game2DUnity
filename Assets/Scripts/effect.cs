using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyS", 0.5f);
    }

    private void DestroyS(){
	Destroy(gameObject);
    }
}
