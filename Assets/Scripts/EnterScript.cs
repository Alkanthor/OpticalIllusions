using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScript : MonoBehaviour
{

    public GameObject player;

    private SettingsScript settingsScript;

	// Use this for initialization
	void Start ()
	{
	    settingsScript = GameObject.Find("Settings").GetComponent<SettingsScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (settingsScript.enableVR)
        {
            player = GameObject.Find("PlayerVR");
            if (Vector3.Distance(transform.position, player.transform.position) < 0.5)
            {
                Debug.Log("Loading : " + this.transform.parent.name.Replace("painting-", ""));
                Application.LoadLevel(this.transform.parent.name.Replace("painting-",""));
            }
        }
        else
        {
            player = GameObject.Find("FPSController");
            if (Vector3.Distance(transform.position, player.transform.position) < 1.5)
            {
                Debug.Log("Loading : " + this.transform.parent.name.Replace("painting-", ""));

                Application.LoadLevel(this.transform.parent.name.Replace("painting-", ""));
            }
        }
        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
    }

  
}
