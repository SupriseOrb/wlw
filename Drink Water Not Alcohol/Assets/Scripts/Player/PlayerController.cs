using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        movement();
        spriteFixer();
    }

    private void movement()
    {
        // if(Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) &&
        //     Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
        //     {
                
        //     }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce (movement*speed, ForceMode2D.Impulse);
        //transform.Translate(moveHorizontal, moveVertical, 0);
    }

    private void spriteFixer()
    {
        transform.position = new Vector3(transform.position.x, 
                                            transform.position.y, 
                                            transform.position.y * 0.01f);
    }
}
