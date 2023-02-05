using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float moveSpeed = 1f;
    public float jumpForce = 60f;
    private bool isJumping;

    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     moveHorizontal = Input.GetAxisRaw("Horizontal");  
     moveVertical = Input.GetAxisRaw("Vertical");   

    // Debug.Log(moveVertical);
     if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            if (transform.position.y < 1) 
            {
                    
               
            }

            isJumping = false;
        }
        else
        {
            
        }
    }

    private void FixedUpdate() 
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        if (!isJumping && moveVertical > 0.1f) {
            rb.AddForce(new Vector2(0f, moveVertical), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ground") {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Ground") {
            isJumping = true;
        }
    }
}
