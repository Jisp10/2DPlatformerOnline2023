using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 10f;
    public float JumpSpeed = 500f;

    private Rigidbody2D _rigidbody;

    #region Input Variables

    private float _XInput;
   
    private bool _isJumpPressed = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() // happens every frame
    {
        //Key board A/D or Left/Right arrow
        //Controller stick Left/Right??
        _XInput = Input.GetAxisRaw("Horizontal");
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }
    }

    private void FixedUpdate() //Only happens every 0.02 seconds (unless changed in settings)
    {
        //_rigidbody.AddForce(new Vector2(_XInput, 0f), ForceMode2D.Force);
        
        _rigidbody.velocity = new Vector2(_XInput * MoveSpeed * Time.deltaTime, _rigidbody.velocity.y);

        if (_isJumpPressed && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        _isJumpPressed = false;
    }

    private bool _isGrounded = false;
    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
