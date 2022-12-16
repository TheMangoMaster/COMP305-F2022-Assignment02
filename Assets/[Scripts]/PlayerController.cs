using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = false;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float groundRadius = 0.15f;
    [SerializeField] private Transform Posgroundcheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float JumpForce = 800.0f;
    [SerializeField] private float waitTime = 0.5f;
    private float waitTimeSet = 0;
    private bool facingRight = true;
    private Rigidbody2D gBody;
    // Start is called before the first frame update
    void Start()
    {
        gBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float hrz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();
        // Code for jumping
        if (isGrounded && waitTimeSet <= 0f && Input.GetAxis("Jump") > 0)
        {
            gBody.AddForce(new Vector2(0.0f, JumpForce));
            waitTimeSet = waitTime;
            isGrounded = false;
        }
        else if (waitTimeSet > 0)
        {
            waitTimeSet -= Time.deltaTime;
        }

        if (facingRight == false && hrz > 0)
        {
            flip();
        }
        else if (facingRight == true && hrz < 0)
        {
            flip();
        }

        gBody.velocity = new Vector2(hrz * speed, gBody.velocity.y);
    }
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(Posgroundcheck.position, groundRadius, GroundLayer);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Spikes")
        {
            Debug.Log("Ouch!");
        }
    }

}
