using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class SettingsScript : MonoBehaviour
{

    public bool enableVR;

    public GameObject playerVR;
    public GameObject fpsController;
    public GameObject vrHead;
    public Vector3 initPoition;

    private GameObject floor;

	// Use this for initialization
	void Start ()
	{
        enableVR = true;
        XRSettings.enabled = true;
        playerVR = GameObject.Find("PlayerVR");
        fpsController = GameObject.Find("FPSController");
        floor = GameObject.Find("floor");
        vrHead = GameObject.Find("Camera (eye)");
        InputTracking.disablePositionalTracking = true;
        TurnVR();
    }

    // Update is called once per frame
    void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        enableVR = !enableVR;
            TurnVR();
        }
        vrHead.transform.localPosition = new Vector3(0.0f, 1.55f, 0.0f);

    }

    private void TurnVR()
    {
        if (enableVR)
        {
            playerVR.SetActive(true);
            XRSettings.enabled = true;
            fpsController.SetActive(false);
            floor.GetComponent<Collider>().enabled = false;
            vrHead.transform.localPosition = new Vector3(0.0f, 1.55f, 0.0f);
        }
        else
        {
            playerVR.SetActive(false);
            XRSettings.enabled = false;
            fpsController.SetActive(true);
            floor.GetComponent<Collider>().enabled = true;
            Cursor.visible = false;
        }
    }
}
