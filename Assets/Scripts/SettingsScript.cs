using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{

    public bool enableVR;

    private GameObject playerVR;
    private GameObject fpsController;

    private GameObject floor;

	// Use this for initialization
	void Start ()
	{
	    enableVR = true;
        UnityEngine.XR.XRSettings.enabled = true;
        playerVR = GameObject.Find("PlayerVR");
        fpsController = GameObject.Find("FPSController");
        floor = GameObject.Find("floor");


        playerVR.SetActive(true);
        fpsController.SetActive(false);
	    floor.GetComponent<Collider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        enableVR = !enableVR;
            UnityEngine.XR.XRSettings.enabled = !UnityEngine.XR.XRSettings.enabled;
            TurnVR();
        }
    }

    private void TurnVR()
    {
        if (enableVR)
        {
            playerVR.SetActive(true);
            fpsController.SetActive(false);
            floor.GetComponent<Collider>().enabled = false;
        }
        else
        {
            playerVR.SetActive(false);
            fpsController.SetActive(true);
            floor.GetComponent<Collider>().enabled = true;
        }
    }
}
