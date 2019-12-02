using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    //floats
    public float maxSpeed = 3;
    public float speed = 300f;
    public float jumpPower = 800f;

    //booleans
    bool grounded = true;

    //stats
    public int curHealth;
    public int maxHealth = 100;

    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }



        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            grounded = false;
        }



        //Limiting the speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}