using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using System;

public class MarioMovement : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpImpulseForce = 20f;
    public float jumpSustainForce = 7.5f;
    public float maxHorizontalSpeed = 6f;

    public bool feetTouchGround = false;

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        feetTouchGround = Physics.Raycast(transform.position, Vector3.down, bounds.extents.y + 0.1f);

        var axis = Input.GetAxis("Horizontal");
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if(feetTouchGround && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpImpulseForce, ForceMode.Impulse);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpSustainForce, ForceMode.Force);
        }

        float xVelocity = Math.Clamp(body.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);

        if(Math.Abs(axis) < 0.1f)
        {
            xVelocity *= 0.9f;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxHorizontalSpeed += 10f;
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxHorizontalSpeed += -10f;
        }

        body.velocity = new Vector3(xVelocity, body.velocity.y, body.velocity.z);

        float speed = body.velocity.magnitude;
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
        animator.SetBool("Jumping", !feetTouchGround);
    }
}
