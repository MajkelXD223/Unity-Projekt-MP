using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 5.0f;
    private bool isGrounded = true;
    private Rigidbody2D _rb;
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter (Collision collision)
    {
        isGrounded = true;
    }
    void OnCollisionExit (Collision collision)
    {
        isGrounded = false;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
           
        }
        
    }

    void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
}
