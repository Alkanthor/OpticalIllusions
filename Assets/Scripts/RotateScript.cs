using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public Animator animator;

    private bool animate;


    void Start()
    {
        animate = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animate = !animate;
            animator.SetBool("Animate",animate);
        }
    }


}
