using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylindersSettingsScript : SettingsScript {

    public GameObject VrMirror;
    public GameObject FpsMirror;
    private SettingsScript settings;


    // Use this for initialization
    void Start () {
         VrMirror = GameObject.Find("VRmirror");
        FpsMirror = GameObject.Find("FPSmirror");

        settings = GameObject.Find("Settings").GetComponent<SettingsScript>();

        VrMirror.SetActive(settings.enableVR);
        FpsMirror.SetActive(!settings.enableVR);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                VrMirror.SetActive(settings.enableVR);
                FpsMirror.SetActive(!settings.enableVR);
        }
    }
}
