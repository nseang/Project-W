using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float moveSpeed;


    private Rigidbody myRigidBody;
    private bool grounded;

    private bool facingRight;

    private bool jumpButton;

	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody>();
        facingRight = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");


        HandleInput();
        Flip(horizontal);
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Movement(horizontal);
    }

    private void HandleInput()
    {
        //Jump
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jumpButton = true;
        }
    }

    private void Movement(float horizontal)
    {
        //Horizontal Movement
        myRigidBody.velocity = new Vector2(horizontal * moveSpeed, myRigidBody.velocity.y);



        //Jump
        if (grounded && jumpButton)
        {
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            jumpButton = false;
        }
    }

    private void Flip(float horizontal)
    {
        Vector3 scale = transform.localScale;

        if (horizontal < 0 && facingRight)
        {
            scale.x *= -1;
            transform.localScale = scale;
            facingRight = false;
        }
        if (horizontal > 0 && !facingRight)
        {
            scale.x *= -1;
            transform.localScale = scale;
            facingRight = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {

        if(other.tag == "Ground")
        {
            grounded = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}
