using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFlowScript : MonoBehaviour
{

    // Use this for initialization
    public Animator animator;

    public LightsScript lightsScript;

    public SculptureScript sculptureScript;

    public int modelIndex;


    // Use this for initialization
    void Start()
    {
        sculptureScript = GameObject.Find("Sculpture").GetComponent<SculptureScript>();
        animator = GameObject.Find("Sculpture").GetComponent<Animator>();

        animator.SetTrigger("Animate");
        modelIndex = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (modelIndex == sculptureScript.sculptures.Length)
        {
            Application.LoadLevel("Gallery");
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            animator.SetTrigger("Animate");
            sculptureScript.NextModel();
            modelIndex++;
        }
    }
}
