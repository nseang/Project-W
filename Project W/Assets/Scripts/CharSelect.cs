using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour {

    [SerializeField]
    private CanvasGroup canvas01;

    [SerializeField]
    private NetworkCustom net;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("p"))
        {
            Show();
        }
		
	}

    public void Hide()
    {
        canvas01.alpha = 0f;
        canvas01.blocksRaycasts = false;
    }

    public void Show()
    {
        canvas01.alpha = 1f;
        canvas01.blocksRaycasts = true;
    }

    public void Char1()
    {
        net.setChar(0);
        Hide();
    }

    public void Char2()
    {
        net.setChar(1);
        Hide();
    }

    public void Char3()
    {
        net.setChar(2);
        Hide();
    }

    public void Char4()
    {
        net.setChar(3);
        Hide();
    }

    public void Char5()
    {
        net.setChar(4);
        Hide();
    }
}
