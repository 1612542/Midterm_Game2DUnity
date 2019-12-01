using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour
{
    public float hp=200f;
    public float mana = 180f;
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

	    if (Input.GetKey(KeyCode.LeftArrow) )
        {
            tf.rotation = Quaternion.Euler(0, 180, 0);
        }
            
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.rotation = Quaternion.Euler(0, 0, 0);
        }      

	    if (Input.GetKeyDown(KeyCode.X) && onGround)
        {
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
		    if (tf.rotation.y == 0)
                rb.AddForce(new Vector2(150, 0));
		    else
                rb.AddForce(new Vector2(-150, 0));
	    	animator.SetBool("hitZ", true);
        }

	    if (Input.GetKeyUp(KeyCode.Z))
		    animator.SetBool("hitZ",false);

	    if (Input.GetKeyDown(KeyCode.V) )
        {
            animator.SetBool("hitCV", true);
            if (mana > 0)
            {
                GameObject bullet2 = (GameObject)Instantiate(bulletRef2, firePoint.position, firePoint.rotation);
            }
            mana -= 30f;
            if (mana <= 0)
                mana = 0;
        }

	    if (onGround)
		    animator.SetBool("onGround",true);
	    else
            animator.SetBool("onGround",false);

	    if (hp <= 0 && !deadEffect)
        {
		    deadEffect = true;
		    GameObject b = (GameObject)Instantiate(deadRef, firePoint.position, firePoint.rotation);
		    gameObject.GetComponent<Renderer>().enabled = false;
	    }
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "dietrap")
        {
            hp = 0;
        }
        if (col.gameObject.tag == "enemy")
        {
            rb.AddForce(-transform.right * 50);
            animator.Play("hurt");
            hp -= 20;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ebullet" || col.gameObject.tag == "ebullet3")
        {
            rb.AddForce(-transform.right * 50);
            animator.Play("hurt");
            hp -= 20;
            Destroy(col.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "ground")  
             onGround = false;
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "ground")  
             onGround = true;
    }
}
