using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public SculptureScript sculptureScript;


    // Use this for initialization
    void Start () {
        sculptureScript = GameObject.Find("Sculpture").GetComponent<SculptureScript>();
    }

    // Update is called once per frame
    void Update () {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
            sculptureScript.NextModel();
        if (scroll < 0)
            sculptureScript.PreviousModel();
    }
}
