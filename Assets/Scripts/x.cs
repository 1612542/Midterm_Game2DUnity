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
    public Transform firePoint;
    Object bulletRef;
    Object bulletRef2;
    bool onGround = false;
    void Start()
    {
	speed = Time.deltaTime;
	bulletRef = Resources.Load("bullet");
	bulletRef2 = Resources.Load("bullet2");
    }
    // Update is called once per frame
    void Update()
    {
	speed = Mathf.Abs(Input.GetAxisRaw("Horizontal") * Time.deltaTime);
	animator.SetFloat("speed", 100*speed);
	tf.Translate(new Vector2(speed, 0));

	if (Input.GetKey(KeyCode.LeftArrow)){
            	tf.rotation = Quaternion.Euler(0, 180, 0);
        }
            
        if (Input.GetKey(KeyCode.RightArrow))
        {
            	tf.rotation = Quaternion.Euler(0, 0, 0);
        }      
	if (Input.GetKeyDown(KeyCode.X) && onGround )
        {
	    animator.SetBool("jump", true);
            rb.AddForce(new Vector2(0, 200));
        }
	if (Input.GetKeyDown(KeyCode.C))
	{
		animator.SetBool("shoot",true);
		GameObject bullet = (GameObject)Instantiate(bulletRef, firePoint.position, firePoint.rotation);
	}
	if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.V))
	{
		animator.SetBool("shoot", false);
	}
	
	if (Input.GetKeyDown(KeyCode.Z) && onGround)
        {
		if (tf.rotation.y == 0) rb.AddForce(new Vector2(150, 0));
		else rb.AddForce(new Vector2(-150, 0));
	    	animator.SetBool("dash", true);
        }
	if (Input.GetKeyUp(KeyCode.Z))
		animator.SetBool("dash",false);
	if (Input.GetKeyDown(KeyCode.V))
        {
		animator.SetBool("shoot",true);
		GameObject bullet2 = (GameObject)Instantiate(bulletRef2, firePoint.position, firePoint.rotation);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ground") {
		animator.SetBool("jump",false);
		onGround =true;
	}
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.name=="ground")  
            onGround = false;
    }

}
