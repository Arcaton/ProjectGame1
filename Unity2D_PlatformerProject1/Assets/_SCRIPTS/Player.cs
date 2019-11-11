using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float maxSpeed = 3;
    public float speed = 300f;
    public float jumpPower = 800f;

     bool grounded = true;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("jsfhjksdhgf");
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
}