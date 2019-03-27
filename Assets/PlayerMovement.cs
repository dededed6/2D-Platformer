using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movePower = 1f;
    public float dashPower = 1f;

    private void FixedUpdate()
    {
        Move();
        Dash();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Dash()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 dashVelocity = Vector3.zero;
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.position += Vector3.down * dashPower;
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
         {
                transform.position += Vector3.up * dashPower;
         }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                transform.position += Vector3.left * dashPower;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                transform.position += Vector3.right * dashPower;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().gravityScale = 1.5f;
    }
}