using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public Transform GroundCheck;
    public LayerMask WhatIsGround;
    public float jumpForce = 2f;

    private bool grounded = false;
    private float GroundRadius = 0.1f;
    private Rigidbody2D body;
    private Animator animator;
    private bool directionRight = true;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, WhatIsGround);
        animator.SetBool("Ground", grounded);

        float move = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(maxSpeed * move, body.velocity.y);

        if(move != 0f)
        {
            animator.SetFloat("walk", Mathf.Abs(move));
        }
        else
        {
            animator.SetFloat("walk", 0f);
        }

        if(move > 0 && !directionRight)
        {
            Flip();
        }
        else if(move < 0 && directionRight)
        {
            Flip();
        }
	}

    private void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Ground", false);
            body.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        directionRight = !directionRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
