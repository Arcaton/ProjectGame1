using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 400f;

    public bool grounded;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * jumpPower);
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