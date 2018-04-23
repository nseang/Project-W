using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    Rigidbody pBullet;
    [SerializeField]
    GameObject[] faces;


    private Rigidbody myRigidBody;
    private bool grounded;
    private bool onWall;

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
        //Debug.Log();
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Movement(horizontal, vertical);
    }

    private void HandleInput()
    {
        //Jump
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jumpButton = true;
        }

        //Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Movement(float horizontal, float vertical)
    {
        //Movement
        myRigidBody.velocity = new Vector3(horizontal * moveSpeed, myRigidBody.velocity.y,vertical * (moveSpeed/2));

        
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

    private void Shoot()
    {
        foreach(GameObject point in faces)
        {
            Rigidbody pBulletClone = Instantiate(pBullet, point.transform.position, point.transform.rotation);
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
    
    public bool getFacingRight()
    {
        return facingRight;
    }

    public void setGrounded(bool isGrounded)
    {
        grounded = isGrounded;
    }
}
