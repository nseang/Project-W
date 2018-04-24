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

    private float rotationX = 0.0f;
    private float rotationSpeed;
    private Transform camTransform;


    private Rigidbody myRigidBody;
    private Vector3 moveVector;

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
        //Debug.Log();
	}

    private void FixedUpdate()
    {
        moveVector = DirInput();

        moveVector = RotateWithView();

        Movement();
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

    private void Movement()
    {
        //Movement
        //myRigidBody.velocity = new Vector3(horizontal * moveSpeed, myRigidBody.velocity.y,vertical * (moveSpeed/2));
        myRigidBody.AddForce((moveVector * moveSpeed));


        //Rotate with camera

        
        //Jump
        if (grounded && jumpButton)
        {
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            jumpButton = false;
        }

    }

    private void Shoot()
    {
        foreach(GameObject point in faces)
        {
            Rigidbody pBulletClone = Instantiate(pBullet, point.transform.position, point.transform.rotation);
        }
    }

    private Vector3 DirInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if(dir.magnitude > 1)
        {
            dir.Normalize();
        }

        return dir;
    }

    private Vector3 RotateWithView()
    {
        if (camTransform != null)
        {
            Vector3 dir = camTransform.TransformDirection(moveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * moveVector.magnitude;
        }
        else
        {
            camTransform = Camera.main.transform;
            return moveVector;
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
