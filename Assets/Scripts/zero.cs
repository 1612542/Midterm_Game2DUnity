using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zero : MonoBehaviour
{
    public float hp = 200f;
    float speed = 0f;
    public SpriteRenderer sr;
    public Transform tf;
    public Rigidbody2D rb;
    public Animator animator;
    bool onGround = false;
    Object deadRef;
    bool deadEffect = false;
    public Transform atkPos, flamePos, icePos, thunderPos, hurricanePos;
    public float atkRX, flameRX, iceRX, thunderRX, hurricaneRX;
    public float atkRY, flameRY, iceRY, thunderRY, hurricaneRY;
    public LayerMask enemy;

    // Start is called before the first frame update
    void Start()
    {
        speed = Time.deltaTime;
        deadRef = Resources.Load("dead");
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Abs(Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        animator.SetFloat("speed", 200 * speed);
        tf.Translate(new Vector2(speed, 0));

        if (Input.GetKey(KeyCode.LeftArrow))
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("hitC");
            Collider2D[] enemies = Physics2D.OverlapBoxAll(atkPos.position, new Vector2(atkRX, atkRY), 0, enemy);
            for (int i=0; i < enemies.Length; i++)
                enemies[i].GetComponent<Enemy>().TakeDamage(20);
        }

        if ( Input.GetKeyDown(KeyCode.A) && !onGround)
        {
            animator.SetTrigger("ice");
            Collider2D[] enemies = Physics2D.OverlapBoxAll(atkPos.position, new Vector2(iceRX, iceRY), 0, enemy);
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].GetComponent<Enemy>().TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.S) && onGround)
        {
            animator.SetTrigger("flame");
            rb.AddForce(new Vector2(0, 200));
            Collider2D[] enemies = Physics2D.OverlapBoxAll(flamePos.position, new Vector2(flameRX, flameRY), 0, enemy);
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].GetComponent<Enemy>().TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("thunder");
            Collider2D[] enemies = Physics2D.OverlapBoxAll(thunderPos.position, new Vector2(thunderRX, thunderRY), 0, enemy);
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].GetComponent<Enemy>().TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("hurricane");
            Collider2D[] enemies = Physics2D.OverlapBoxAll(hurricanePos.position, new Vector2(hurricaneRX, hurricaneRY), 0, enemy);
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].GetComponent<Enemy>().TakeDamage(20);
        }




        if (Input.GetKeyDown(KeyCode.Z) && onGround)
        {
            if (tf.rotation.y == 0)
                rb.AddForce(new Vector2(150, 0));
            else
                rb.AddForce(new Vector2(-150, 0));
            animator.SetBool("hitZ", true);
        }

        if (Input.GetKeyUp(KeyCode.Z))
            animator.SetBool("hitZ", false);

       

   
        if (onGround)
            animator.SetBool("onGround", true);
        else
            animator.SetBool("onGround", false);

        if (hp <= 0 && !deadEffect)
        {
            deadEffect = true;
            GameObject b = (GameObject)Instantiate(deadRef, tf.position, tf.rotation);
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
        if (col.gameObject.tag == "ground")
            onGround = false;
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
            onGround = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(flamePos.position, new Vector3(flameRX, flameRY, 1));
    }
}
