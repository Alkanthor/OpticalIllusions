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
        SetAnimator();

        Debug.Log("animate");

        animator.SetTrigger("Animate");
        modelIndex = 0;
    }

    private void SetAnimator()
    {
        animator = GameObject.Find("Sculpture").GetComponent<Animator>();
        if (animator == null)
        {
            animator = GameObject.Find("Sculpture").transform.GetChild(modelIndex).GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            animator.SetTrigger("Animate");
            modelIndex++;
            if (modelIndex < sculptureScript.sculptures.Length)
                sculptureScript.NextModel();
            else
            {
                Application.LoadLevel("Menu");
            }
            //SetAnimator();
        }
    }
}
