using UnityEngine;

public class AvatarTransformer : MonoBehaviour
{
    GameObject gamecontroller;

    void Start()
    {
        //　ゲーム開始時にGamecontrollerをFindしておく
        gamecontroller = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter(Collider other)
    {
        //gamecontroller.SendMessage("IncreaseScore");

        // アバターの移動
        if (other.gameObject.tag == "Transform")
        {
            
            // transformを取得
            Transform myTransform = this.transform;

            // 座標を取得
            Vector3 pos = myTransform.position;

            pos.x = Random.Range(-4.5f,4.5f);
            pos.y = 0;
            pos.z = Random.Range(-4.5f, 4.5f);

            // 座標を設定
            myTransform.position = pos;

            // ローカル座標を基準に、回転を取得
            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.x = 0; 
            localAngle.y = 0; 
            localAngle.z = 0; 

            myTransform.localEulerAngles = localAngle; // 回転角度を設定
        }
    }
}
