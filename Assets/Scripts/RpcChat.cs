using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RpcChat : MonoBehaviourPun
{
    string message;
    string getInputText;
    string getName;
    public Text chatText;
    public GameObject window;
    public Text inputtext;
    public Toggle toggle;
    private TouchScreenKeyboard overlayKeyboard;

    void Update()
    {
        // 画面表示
        InputText();

        if (TouchScreenKeyboard.visible == false)
        {
            toggle.isOn = false;
        }
    }

    //　メッセージを送信
    public void SendMessage()
    {
        GetName();
        message = GetInputText();
        photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, message);
        window.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        overlayKeyboard.text = "";
    }

    // キーボード表示
    public void Keyboard()
    {
        if(toggle.isOn == true)
        {
            overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
            
    }

    //インプット表示
    [PunRPC]
    void InputText()
    {
        inputtext.text = overlayKeyboard.text;
    }

    //　アバターの名前を取得
    [PunRPC]
    string GetName()
    {
        //　SceneControllerの名前を取得
        getName = SceneController.avatarName;
        return getName;
    }

    //　メッセージを取得
    [PunRPC]
    string GetInputText()
    {
        getInputText = "";
        getInputText = "  " + getName + " : " + inputtext.text;
        return getInputText;
    }

    //　メッセージの追加
    [PunRPC]
    void RpcSendMessage(string sendMessage)
    {
        chatText.text += sendMessage;
        chatText.text += Environment.NewLine;
    }
}