using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTrigger : MonoBehaviour {

    PlayerController playerScript;




    // Use this for initialization
    void Start () {

       playerScript = transform.parent.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ground")
        {
            playerScript.setOnWall(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        playerScript.setOnWall(false);
    }
}
