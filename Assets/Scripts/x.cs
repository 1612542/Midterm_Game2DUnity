using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour
{
    public float hp=200f;
    float speed = 0f;
    public SpriteRenderer sr;
    public Transform tf;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform firePoint;
    Object bulletRef;
    Object bulletRef2;
    Object deadRef;
    bool onGround = false;
    public GameObject head;
    bool deadEffect = false;
    void Start()
    {
	speed = Time.deltaTime;
	bulletRef = Resources.Load("bullet");
	bulletRef2 = Resources.Load("bullet2");
	deadRef = Resources.Load("dead");
    }
    // Update is called once per frame
    void Update()
    {
	speed = Mathf.Abs(Input.GetAxisRaw("Horizontal") * Time.deltaTime);
	animator.SetFloat("speed", 200*speed);
	tf.Translate(new Vector2(speed, 0));

	if (Input.GetKey(KeyCode.LeftArrow) ){
            	tf.rotation = Quaternion.Euler(0, 180, 0);
        }
            
        if (Input.GetKey(KeyCode.RightArrow)  )
        {
            	tf.rotation = Quaternion.Euler(0, 0, 0);
        }      
	if (Input.GetKeyDown(KeyCode.X) && onGround  )
        {
	    animator.SetBool("jump", true);
            rb.AddForce(new Vector2(0, 250));
        }
	if (Input.GetKeyDown(KeyCode.C) )
	{
		animator.SetBool("hitCV",true);
		GameObject bullet = (GameObject)Instantiate(bulletRef, firePoint.position, firePoint.rotation);
	}
	if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.V) )
	{
		animator.SetBool("hitCV", false);
	}
	
	if (Input.GetKeyDown(KeyCode.Z) && onGround  )
        {
		if (tf.rotation.y == 0) rb.AddForce(new Vector2(150, 0));
		else rb.AddForce(new Vector2(-150, 0));
	    	animator.SetBool("hitZ", true);
        }
	if (Input.GetKeyUp(KeyCode.Z))
		animator.SetBool("hitZ",false);
	if (Input.GetKeyDown(KeyCode.V) )
        {
		animator.SetBool("hitCV",true);
		GameObject bullet2 = (GameObject)Instantiate(bulletRef2, firePoint.position, firePoint.rotation);
        }
	if (onGround)
		animator.SetBool("onGround",true);
	else animator.SetBool("onGround",false);
	if (hp <= 0 && !deadEffect){
		deadEffect = true;
		GameObject b = (GameObject)Instantiate(deadRef, firePoint.position, firePoint.rotation);
		gameObject.GetComponent<Renderer>().enabled = false;
	}
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ground1" || col.gameObject.name == "ground2"
            || col.gameObject.name == "ground5" || col.gameObject.name == "ground6"
            || col.gameObject.name == "ground7" || col.gameObject.name == "helper_barier1"  
            || col.gameObject.name == "barier1" || col.gameObject.name == "barier2"
            || col.gameObject.name == "br1" || col.gameObject.name == "br2"
            || col.gameObject.name == "br3" || col.gameObject.name == "br4"
            || col.gameObject.name == "br5" 
            || col.gameObject.name == "moving_base1" || col.gameObject.name == "moving_base2") 
        {
		  animator.SetBool("jump", false);
		  onGround = true;
	    }
    }

    void OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.tag =="ebullet"){
		rb.AddForce(-transform.right*50);
		animator.Play("hurt");
		hp -=20;
	}

    void OnCollisionExit2D(Collision2D col)
    {
        // if(col.gameObject.name=="Ground1")  
        //     onGround = false;
        if (col.gameObject.name == "ground1" || col.gameObject.name == "ground2"
            || col.gameObject.name == "ground5" || col.gameObject.name == "ground6"
            || col.gameObject.name == "ground7" || col.gameObject.name == "helper_barier1"  
            || col.gameObject.name == "barier1" || col.gameObject.name == "barier2"
            || col.gameObject.name == "br1" || col.gameObject.name == "br2"
            || col.gameObject.name == "br3" || col.gameObject.name == "br4"
            || col.gameObject.name == "br5" 
            || col.gameObject.name == "moving_base1" || col.gameObject.name == "moving_base2")
                onGround = false; 
    }
}
