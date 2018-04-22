using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    private GameObject player;
    private PlayerController playerScript;
    private Transform target;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 offsetR;

    private float smoothSpeed = 4f;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = (PlayerController)player.GetComponent(typeof(PlayerController));
        target = player.transform;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        moveCamera();
    }

    private void moveCamera()
    {

        bool facingRight = playerScript.getFacingRight();




        Vector3 desiredposition;

        if (facingRight)
        {
            desiredposition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        if (!facingRight)
        {
            desiredposition = target.position + offsetR;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }




    }

}
