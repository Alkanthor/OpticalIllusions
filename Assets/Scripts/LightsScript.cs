using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightsScript : MonoBehaviour
{

    private GameObject[] rooms;
    public GameObject light;
    private int activeIndex;

    // Use this for initialization
    void Start()
    {
        activeIndex = 0;
        rooms = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            rooms[i] = transform.GetChild(i).gameObject;
            if (i == activeIndex)
                rooms[i].SetActive(true);
            else
                rooms[i].SetActive(false);
        }
        light.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            activeIndex++;
            activeIndex = mod(activeIndex, transform.childCount);
            Lights();
            light.SetActive(!light.activeSelf);
        }

    }

    private void Lights()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == activeIndex)
                rooms[i].SetActive(true);
            else
                rooms[i].SetActive(false);
        }
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}