using UnityEngine;
using Photon.Pun;
public class AvatarController :MonoBehaviour
{
    private PhotonView photonView;
    public float speed = 1.0f;
    private Rigidbody rb; //リジッドボディを取得するための変数
    public float upForce = 200f; //上方向にかける力
    private bool isGround; //着地しているかどうかの判定

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        //前進
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger) || Input.GetKey(KeyCode.UpArrow)) Forward();

        //後退
        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger) || Input.GetKey(KeyCode.DownArrow))   Back();

        //右回転
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || Input.GetKey(KeyCode.RightArrow)) RRot();

        //左回転
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || Input.GetKey(KeyCode.LeftArrow))  LRot();

        //跳躍
        if((OVRInput.Get(OVRInput.RawButton.Y) || Input.GetKey(KeyCode.Space)))   Jump();

        //正体
        if (OVRInput.Get(OVRInput.RawButton.X) || Input.GetKey(KeyCode.X))  NShape();
    }
        //前進
        void Forward()
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            {
                Debug.Log("右中指グリップを押した");
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("↑ボタンを押した。");

            }
        }
        

         //後退
         void Back()
         {
             transform.position -= transform.forward * speed * Time.deltaTime;

             if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
             {
                Debug.Log("左中指グリップを押した");
             }

             if (Input.GetKey(KeyCode.R))
             {
                Debug.Log("↓ボタンを押した。");

             }
         }
         

         //右回転
         void RRot()
         {
              transform.Rotate(new Vector3(0,10,0));

              if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
              {
                 Debug.Log("右人差し指トリガーを押した");
              }

              if (Input.GetKey(KeyCode.RightArrow))
              {
                 Debug.Log("→ボタンを押した。");
              }
         }
         

         //左回転
         void LRot()
         {
              transform.Rotate(new Vector3(0, -10, 0));

              if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
              {
                 Debug.Log("左人差し指トリガーを押した");
              }

              if (Input.GetKey(KeyCode.LeftArrow))
              {
                 Debug.Log("←ボタンを押した。");
              }
         }
         

         //ジャンプ
         void Jump()
         {
              if (isGround == true)//着地しているとき
              {
                  if (Input.GetKeyDown("space"))
                  {
                       isGround = false;//  isGroundをfalseにする
                       rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
                  }
              }

              if (OVRInput.Get(OVRInput.RawButton.Y))
              {
                  Debug.Log("Yボタンを押した。");
              }

              if (Input.GetKey(KeyCode.Space))
              {
                  Debug.Log("スペースボタンを押した。");
              }
         }
         

        //正体
        void NShape()
        {
            Transform myTransform = this.transform;

            // ローカル座標を基準に、回転を取得
            Vector3 localAngle = myTransform.localEulerAngles;

            localAngle.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
            localAngle.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
            localAngle.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更

            myTransform.localEulerAngles = localAngle; // 回転角度を設定

            if (OVRInput.Get(OVRInput.RawButton.X))
            {
                  Debug.Log("Xボタンを押した。");
            }

             if (Input.GetKey(KeyCode.X))
             {
                  Debug.Log("Xボタンを押した。");

             }
        }

        //地面に触れた時の処理
        void OnCollisionEnter(Collision other) 
        {
            if (other.gameObject.tag == "Ground") //Groundタグのオブジェクトに触れたとき
            {
                isGround = true; //isGroundをtrueにする
            }
        }

}
