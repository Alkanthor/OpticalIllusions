using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylindersSettingsScript : SettingsScript {

    private GameObject VrMirror;
    private GameObject FpsMirror;


    // Use this for initialization
    void Start () {
         VrMirror = GameObject.Find("VRmirror");
        FpsMirror = GameObject.Find("FPSmirror");

        VrMirror.SetActive(enableVR);
        FpsMirror.SetActive(!enableVR);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                VrMirror.SetActive(enableVR);
                FpsMirror.SetActive(!enableVR);
        }
    }
}
