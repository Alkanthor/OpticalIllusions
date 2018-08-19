using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

public class OpenvibeASConnection : MonoBehaviour {

    private ulong OVTCPFLAG_TIMESTAMP_CREATE = 4;
    public string conName = "openvibe";
    public string conHost = "127.0.0.1";
    public int conPort = 15361;
    public bool socketReady = false;

    TcpClient tcpSocket;
    NetworkStream tcpStream;
    StreamWriter tcpWriter;
    StreamReader tcpReader;

    public bool setup()
    {
        try
        {
            tcpSocket = new TcpClient(conHost, conPort);
            tcpStream = tcpSocket.GetStream();
            tcpWriter = new StreamWriter(tcpStream);
            tcpReader = new StreamReader(tcpStream);
            socketReady = true;
            return true;
        }
        catch (Exception e)
        {
            Debug.Log("Could not connect to Openvibe AS: " + e);
            return false;
        }
    }

    public void send(ulong code)
    {
        //Debug.Log("Sending stimulation code " + code + ".");
        if (!socketReady)
        {
            Debug.Log("Could not send the stimulation: socket not ready.");
            return;
        }

        byte[] msg = new byte[8];
        ulong flags = OVTCPFLAG_TIMESTAMP_CREATE;

        msg = BitConverter.GetBytes(flags);
        tcpStream.Write(msg, 0, sizeof(ulong));
        msg = BitConverter.GetBytes(code);
        tcpStream.Write(msg, 0, sizeof(ulong));
        msg = BitConverter.GetBytes((ulong)0);
        tcpStream.Write(msg, 0, sizeof(ulong));

        tcpWriter.Flush();
    }

    public void sendMIRHeader()
    {
        send(OVStimCodes.OVTK_StimulationId_ExperimentStart);
        send(OVStimCodes.OVTK_StimulationId_BaselineStart);
        send(OVStimCodes.OVTK_StimulationId_Beep);
        send(OVStimCodes.OVTK_StimulationId_BaselineStop);
        send(OVStimCodes.OVTK_StimulationId_Beep);
    }

    public void sendMIRFinalize()
    {
        send(OVStimCodes.OVTK_GDF_End_Of_Session);
        send(OVStimCodes.OVTK_StimulationId_Train);
        send(OVStimCodes.OVTK_StimulationId_ExperimentStop);
    }

    public void sendMIRTrialEnd()
    { 
        send(OVStimCodes.OVTK_GDF_End_Of_Trial);
    }

    public string read()
    {
        String result = "";
        if (tcpStream.DataAvailable)
        {
            Byte[] inStream = new Byte[tcpSocket.SendBufferSize];
            tcpStream.Read(inStream, 0, inStream.Length);
            result += System.Text.Encoding.UTF8.GetString(inStream);
        }
        return result;
    }

    public void close()
    {
        if (!socketReady)
            return;
        tcpWriter.Close();
        tcpReader.Close();
        tcpSocket.Close();
        socketReady = false;
    }

    public void maintain()
    {
        if (!tcpStream.CanRead)
        {
            setup();
        }
    }

}
