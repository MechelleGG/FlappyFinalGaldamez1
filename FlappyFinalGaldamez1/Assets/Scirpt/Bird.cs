using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;               //Upward force of the "flap'.
    private bool isDead = false;        //hass the player collided with the wall

    private Animator anim;       //Reference to the Animator component
    private Rigidbody2D rb2d;    //Holds a reference to the Rigidbody2D component of the bird.

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Flap");
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2 (0, upForce));
            }
        }
    }

    void OnCollisionEnter2d(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied ();
    }
}  
