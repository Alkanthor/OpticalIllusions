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

    private OpenvibeASConnection ovconn;

    public bool doOpenvibeASConnection = true;

    private new Dictionary<Vector2Int, ulong> codes = new Dictionary<Vector2Int, ulong>()
        {
            { new Vector2Int(1,1),OVStimCodes.OVTK_StimulationId_Label_1A },
            { new Vector2Int(1,2),OVStimCodes.OVTK_StimulationId_Label_1B },
            { new Vector2Int(1,3),OVStimCodes.OVTK_StimulationId_Label_1C },
            { new Vector2Int(1,4),OVStimCodes.OVTK_StimulationId_Label_1D },
            { new Vector2Int(2,1),OVStimCodes.OVTK_StimulationId_Label_2A },
            { new Vector2Int(3,1),OVStimCodes.OVTK_StimulationId_Label_3A },
            { new Vector2Int(4,1),OVStimCodes.OVTK_StimulationId_Label_4A },
            { new Vector2Int(5,1),OVStimCodes.OVTK_StimulationId_Label_5A },
            { new Vector2Int(5,2),OVStimCodes.OVTK_StimulationId_Label_5B },
            { new Vector2Int(5,3),OVStimCodes.OVTK_StimulationId_Label_5C },
            { new Vector2Int(6,1),OVStimCodes.OVTK_StimulationId_Label_6A },
            { new Vector2Int(6,2),OVStimCodes.OVTK_StimulationId_Label_6B },
            { new Vector2Int(7,1),OVStimCodes.OVTK_StimulationId_Label_7A },
            { new Vector2Int(7,2),OVStimCodes.OVTK_StimulationId_Label_7B },

        };

    void connectOV()
    {
        if (ovconn.socketReady == false)
        {
            Debug.Log("Attempting to connect..");
            ovconn.setup();
            ovconn.send(codes[new Vector2Int(Application.loadedLevel, 1)]);
            Debug.Log("Code sent: " + codes[new Vector2Int(Application.loadedLevel, 1)]);
        }
    }

    IEnumerator sendinit()
    {
        yield return new WaitForSeconds(1);
        ovconn.send(OVStimCodes.OVTK_StimulationId_ExperimentStart);
        Debug.Log("Experiment start");
    }


    // Use this for initialization
    void Start()
    {
        var codes =
        sculptureScript = GameObject.Find("Sculpture").GetComponent<SculptureScript>();
        SetAnimator();

        ovconn = gameObject.AddComponent<OpenvibeASConnection>();
        if (doOpenvibeASConnection)
        {
            connectOV();
            StartCoroutine(sendinit());
        }

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
            {
                sculptureScript.NextModel();
                ovconn.send(codes[new Vector2Int(Application.loadedLevel, modelIndex + 1)]);
                Debug.Log("Code sent: " + codes[new Vector2Int(Application.loadedLevel, modelIndex + 1)]);
            }
            else
            {
                ovconn.send(OVStimCodes.OVTK_StimulationId_ExperimentStop);
                Debug.Log("Experiment end");
                Application.LoadLevel("Menu");
            }
            SetAnimator();
        }
    }
}
