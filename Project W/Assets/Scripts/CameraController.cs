using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    private GameObject player;
    private PlayerController playerScript;
    private Transform target;
    private Transform camTransform;
    private Camera cam;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 offsetR;
    [SerializeField]
    private float currentX = 0.0f;
    [SerializeField]
    private float currentY = 0.0f;

    private float smoothSpeed = 4f;

    private float distance = 10.0f;
  
  //  private float sensitivityX = 4.0f;
  //  private float sensitivityY = 1.0f;



    // Use this for initialization
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = (PlayerController)player.GetComponent(typeof(PlayerController));
        target = player.transform;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = target.position + rotation * dir;
    }

    void FixedUpdate()
    {
       // moveCamera();
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
