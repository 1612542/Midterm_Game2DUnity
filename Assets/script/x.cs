using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour
{
    float speed = 0f;
    public SpriteRenderer sr;
    public Transform tf;
    public Rigidbody2D rb;
    public Animator animator;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
	animator.SetFloat("speed", Mathf.Abs(speed));
	tf.Translate(new Vector2(speed, 0));
	if (Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
        }
            
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
        }      
	if (Input.GetKeyDown(KeyCode.X))
        {
	    jump = true;
            //rb.AddForce(new Vector2(0, 200));
        }
    }

}
