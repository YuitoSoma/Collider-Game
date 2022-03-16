using Photon.Voice.Unity;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    public Recorder recorder;

    void Awake()
    {
        recorder.TransmitEnabled = true;
    }
    public void voiceController()
    {
        if (recorder.TransmitEnabled)
        {
              //ミュート
              recorder.TransmitEnabled = false;
        }
        else
        {
              //再開
              recorder.TransmitEnabled = true;
        }
    }
}
