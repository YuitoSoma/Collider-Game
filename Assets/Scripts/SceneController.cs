using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class SceneController : MonoBehaviourPunCallbacks
{
    public GameObject[] avatarObject;
    public string[] avatarResource;
    public GameObject OVRCamera;
    public static string avatarName;

    void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("接続");
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        Debug.Log("参加");
    }

    //アバターのリソースからランダムに1つ選ぶ
     public string SampleAvatar()
     {
        int index = Random.Range(0, avatarObject.Length);
        avatarResource[index] = avatarObject[index].name;
        avatarName = avatarResource[index];
        return avatarResource[index];
     }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        GameObject avatar = PhotonNetwork.Instantiate(SampleAvatar(), new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, Random.Range(-4.5f, 4.5f)), Quaternion.identity, 0);
        Debug.Log("生成");

        //avatarの子にOVRCameraを配置
        OVRCamera.transform.parent = avatar.transform;

        //座標の同期
        OVRCamera.transform.position = avatar.transform.position + new Vector3(0f, 0.5f, 0f);
    }
}