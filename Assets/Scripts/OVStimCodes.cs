static class OVStimCodes
{
    public const ulong OVTK_StimulationId_ExperimentStart = 0x00008001;
    public const ulong OVTK_StimulationId_ExperimentStop = 0x00008002;
    public const ulong OVTK_StimulationId_SegmentStart = 0x00008003;
    public const ulong OVTK_StimulationId_SegmentStop = 0x00008004;
    public const ulong OVTK_StimulationId_TrialStart = 0x00008005;
    public const ulong OVTK_StimulationId_TrialStop = 0x00008006;
    public const ulong OVTK_StimulationId_BaselineStart = 0x00008007;
    public const ulong OVTK_StimulationId_BaselineStop = 0x00008008;
    public const ulong OVTK_StimulationId_Train = 0x00008201;
    public const ulong OVTK_StimulationId_Beep = 0x00008202;
    public const ulong OVTK_StimulationId_Target = 0x00008205;
    public const ulong OVTK_StimulationId_NonTarget = 0x00008206;
    public const ulong OVTK_StimulationId_TrainCompleted = 0x00008207;
    public const ulong OVTK_StimulationId_Reset = 0x00008208;
    public const ulong OVTK_GDF_Start_Of_Trial = 0x300;
    public const ulong OVTK_GDF_Left = 0x301;
    public const ulong OVTK_GDF_Right = 0x302;
    public const ulong OVTK_GDF_Feedback_Continuous = 0x30D;
    public const ulong OVTK_GDF_Beep = 0x311;
    public const ulong OVTK_GDF_Cross_On_Screen = 0x312;
    public const ulong OVTK_GDF_End_Of_Trial = 0x320;
    public const ulong OVTK_GDF_Correct = 0x381;
    public const ulong OVTK_GDF_Incorrect = 0x382;
    public const ulong OVTK_GDF_End_Of_Session = 0x3F2;
    public const ulong OVTK_GDF_Left_Hand_Movement = 0x441;
    public const ulong OVTK_GDF_Right_Hand_Movement = 0x442;

    //Ambiguous cylinders
    public const ulong OVTK_StimulationId_Label_1A = 0x0000811a;
    public const ulong OVTK_StimulationId_Label_1B = 0x0000811b;
    public const ulong OVTK_StimulationId_Label_1C = 0x0000811c;
    public const ulong OVTK_StimulationId_Label_1D = 0x0000811d;

    //Ames room
    public const ulong OVTK_StimulationId_Label_2A = 0x0000812a;

    //Following eyes
    public const ulong OVTK_StimulationId_Label_3A = 0x0000813a;

    //Magnetic slopes
    public const ulong OVTK_StimulationId_Label_4A = 0x0000814a;
    public const ulong OVTK_StimulationId_Label_4B = 0x0000814b;

    //Penrose triangle
    public const ulong OVTK_StimulationId_Label_5A = 0x0000815a;
    public const ulong OVTK_StimulationId_Label_5B = 0x0000815b;
    public const ulong OVTK_StimulationId_Label_5C = 0x0000815c;

    //Silouhetes
    public const ulong OVTK_StimulationId_Label_6A = 0x0000816a;
    public const ulong OVTK_StimulationId_Label_6B = 0x0000816b;

    //Yes/No
    public const ulong OVTK_StimulationId_Label_7A = 0x0000817a;
    public const ulong OVTK_StimulationId_Label_7B = 0x0000817b;
}