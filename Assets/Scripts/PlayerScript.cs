using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Animator animator;

    public LightsScript lightsScript;

    private bool animate;

    public SculptureScript sculptureScript;


    // Use this for initialization
    void Start ()
    {
        animate = false;
        sculptureScript = GameObject.Find("Sculpture").GetComponent<SculptureScript>();
        animator = GameObject.Find("Sculpture").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animate = !animate;
            animator.SetBool("Animate", animate);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            lightsScript.TurnLights();
        }
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
            sculptureScript.NextModel();
        if (scroll < 0)
            sculptureScript.PreviousModel();
    }
}
