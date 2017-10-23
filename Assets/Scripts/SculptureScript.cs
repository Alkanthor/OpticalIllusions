using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SculptureScript : MonoBehaviour
{

    private GameObject[] sculptures;
    private int activeIndex;

	// Use this for initialization
	void Start ()
	{
	    activeIndex = 0;
        sculptures = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            sculptures[i] = transform.GetChild(i).gameObject;
            if (i == activeIndex)
                sculptures[i].SetActive(true);
           else
                sculptures[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            activeIndex++;
            activeIndex = mod(activeIndex, transform.childCount);
            ChangeModel();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            activeIndex--;
            activeIndex = mod(activeIndex,transform.childCount);
            ChangeModel();
        }
    }

    private void ChangeModel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == activeIndex)
                sculptures[i].SetActive(true);
            else
                sculptures[i].SetActive(false);
        }
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}
