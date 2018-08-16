using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SculptureScript : MonoBehaviour
{

    public GameObject[] sculptures;
    private List<GameObject> balls;
    private Vector3[] origins;
    public int activeIndex;

    // Use this for initialization
    void Start()
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
        SetBallsOrigin();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextModel();
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            PreviousModel();
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
        ResetBalls();
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    private void SetBallsOrigin()
    {
        balls = new List<GameObject>(Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.Contains("Ball")));
        origins = new Vector3[balls.Count];
        for (int i = 0; i < balls.Count; i++)
        {
            origins[i] = balls[i].transform.localPosition;
        }
    }


    private void ResetBalls()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].transform.localPosition = origins[i];
        }
    }

    public void NextModel()
    {
        activeIndex++;
        activeIndex = mod(activeIndex, transform.childCount);
        ChangeModel();
    }

    public void PreviousModel()
    {
        activeIndex--;
        activeIndex = mod(activeIndex, transform.childCount);
        ChangeModel();
    }

    public void LoadModel(int index)
    {
        activeIndex = index;
        ChangeModel();
    }

}