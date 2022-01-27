using Photon.Voice.Unity;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    public Recorder recorder;
    void Update()
    {
        //再開
        if (OVRInput.Get(OVRInput.RawButton.A) || Input.GetKey(KeyCode.R))
        {
            recorder.TransmitEnabled = true;

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                Debug.Log("Aボタンを押した。");

            }

            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Rボタンを押した。");

            }

        }

        //ミュート
        if (OVRInput.Get(OVRInput.RawButton.B) || Input.GetKey(KeyCode.M))
        {
            recorder.TransmitEnabled = false;

            if (OVRInput.Get(OVRInput.RawButton.B))
            {
                Debug.Log("Bボタンを押した。");

            }

            if (Input.GetKey(KeyCode.M))
            {
                Debug.Log("Mボタンを押した。");

            }
        }
    }
}
