using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    public float moveSpeed = 1f;
    public float jumpForce = 60f;
    public float maxSpeed = 5f;
    private bool _isJumping;

    private float _moveHorizontal;
    private float _moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        _isJumping = false;

        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     _moveHorizontal = Input.GetAxisRaw("Horizontal");  
     _moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() 
    {
        if (_moveHorizontal > 0.1f || _moveHorizontal < -0.1f ) {
            _rb.AddForce(new Vector2(_moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            if (_rb.velocity.magnitude >= maxSpeed)
            {
                _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);
            }
        }
        if (!_isJumping && _moveVertical > 0.1f) {
            _rb.AddForce(new Vector2(0f, _moveVertical * jumpForce), ForceMode2D.Impulse);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground")) {
            _isJumping = false;
        }
    }
    

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")) {
            _isJumping = true;
            
        }
    }
}
