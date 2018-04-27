using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CameraController : NetworkBehaviour {

    private const float Y_ANGLE_MIN = 0.0F;
    private const float Y_ANGLE_MAX = 50.0f;


    private GameObject player;
    private Transform target;
    private Transform camTransform;
    private Camera cam;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 offsetR;
 
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float smoothSpeed = 4f;
    private float distance = 10.0f;
  
    public float sensitivityX = 3.0f;
    public float sensitivityY = 2.0f;



    // Use this for initialization
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;

        FindLocalPlayer();

        //player = GameObject.FindGameObjectWithTag("Player");
        //target = player.transform;


    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        if(target == null)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = target.position + rotation * dir;
        camTransform.LookAt(target.position);
    }

    void FixedUpdate()
    {
        
    }

    public void FindLocalPlayer()
    {
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                target = player.transform;
            }
        }
    }


}
