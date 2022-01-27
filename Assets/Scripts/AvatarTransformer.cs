using UnityEngine;

public class AvatarTransformer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // アバターの移動
        if (other.gameObject.tag == "Transform")
        {
            
            // transformを取得
            Transform myTransform = this.transform;

            // 座標を取得
            Vector3 pos = myTransform.position;

            pos.x = 0;    // x座標へ0.01加算
            pos.y = 0;    // y座標へ0.01加算
            pos.z = 0;    // z座標へ0.01加算

            myTransform.position = pos;  // 座標を設定

            // ローカル座標を基準に、回転を取得
            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
            localAngle.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
            localAngle.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更

            myTransform.localEulerAngles = localAngle; // 回転角度を設定

        }
    }
}
