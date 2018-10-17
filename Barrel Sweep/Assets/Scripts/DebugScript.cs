using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
            GameManager.instance.GameOver();

        if (Input.GetKeyDown(KeyCode.Q) || (Input.GetKeyDown(KeyCode.E)))
            GameManager.instance.BarrelSweep();
	}
}
