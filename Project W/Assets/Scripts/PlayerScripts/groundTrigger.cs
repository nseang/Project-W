using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTrigger : MonoBehaviour {

    PlayerController playerScript;




    // Use this for initialization
    void Start()
    {

        playerScript = transform.parent.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            playerScript.setGrounded(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        playerScript.setGrounded(false);
    }

}
