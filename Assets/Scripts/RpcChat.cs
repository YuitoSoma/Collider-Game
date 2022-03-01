using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RpcChat : MonoBehaviourPun
{
    string message;
    string getInputText;
    string getName;
    
    public InputField inputField;
    public Text chatText;
    public GameObject window;
    public GameObject Chat;

    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        chatText.text = "";
        Chat.SetActive(false);
    }

    void Update()
    {
        //　チャットの表示
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Chat.activeSelf)
            {
                //　非表示
                Chat.SetActive(false);
            }
            else
            {
                //　表示
                Chat.SetActive(true);
            }
        }
    }

    //　メッセージを送信
    public void SendMessage()
    {
        message = GetInputText();
        photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, message);
        inputField.text = "";
        window.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
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
        getInputText = "  " + getName + " : " + inputField.text;
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