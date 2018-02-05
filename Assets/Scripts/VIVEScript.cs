using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIVEScript : MonoBehaviour {

    public Animator animator;

    public SculptureScript sculptureScript;

    public LightsScript lightsScript;

    private bool animate;

    // 1
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }


    void Awake()
    {
        animate = false;
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        sculptureScript = GameObject.Find("Sculpture").GetComponent<SculptureScript>();
    }

    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");

            animate = !animate;
            animator.SetBool("Animate", animate);
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
            lightsScript.TurnLights();
        }

        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            print("Pressing Touchpad");


            if (touchpad.x > 0.7f)
            {
                print("Moving Right");
                sculptureScript.NextModel();

            }

            else if (touchpad.x < -0.7f)
            {
                print("Moving left");
                sculptureScript.PreviousModel();
            }

        }
    }
}
