using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniCharacter : MonoBehaviour
{
    [Header("** Shooter Sattings **")]
    public GameObject bulletPrefab;     //弾丸のプレハブ
    public GameObject shotPoint;        //打ち出し座標
    public float shotForce = 10f;       //発射の力

    [Header("** Camera Setting **")]
    public GameObject CameraJoint;      //カメラ軸のオブジェクト

    [Header("** Weapon Setting **")]
    public BaseWeapon weapon;           // 武器をアタッチする変数
    private Vector2 _inputMoveValue;    //Moveの入力値
    private Vector2 _inputLookValue;    //Lookの入力値
    private float _inputAttackValue;    //Attackの入力値
    private Vector3 angles;             //キャラクターの向き(角度)



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();     //移動メゾットを呼び出す
        Look();     //回転メゾットを呼び出す

        if(_inputAttackValue > 0)
        {
            weapon.OnTriggerAction();
        }
        
    }

    //移動メソッド
    //引数  ：無し
    //戻り値：無し
    public void Move()
    {
        Vector3 velocity = Vector3. zero;      //速度の変数
        velocity.z = _inputMoveValue.y;        //入力(上下)で前後移動
        velocity.x = _inputMoveValue.x;        //入力(左右)で左右移動

        transform. Translate(velocity * Time. deltaTime);
    }

    //向きメゾット
    //引数  ：無し
    //戻り値：無し
    public void Look()
    {
        angles.x += _inputLookValue.y;      //Y入力でX軸回転
        angles.y += _inputLookValue.x;      //X入力でY軸回転

        //X軸の角度に制限を設ける
        //↓範囲に制限を設ける数学関数
        //[Mathf.Clamp(対象値、　最小値、　最大値)]
        angles.x = Mathf.Clamp(angles.x, -90, 90);
        
        //TPSプレイヤーのY軸だけ回転
        transform. eulerAngles = new Vector3(0, angles.y, 0);    //角度を代入
        //CameraJointのX軸を回転
        CameraJoint.transform. eulerAngles = new Vector3(angles.x, -angles.y, 0);
    }

    //=== inputAction [Move]のイベント処理
    public void OnMove(InputValue value)
    {
        _inputMoveValue = value.Get<Vector2>();
    }

    //=== inputAction [Look]のイベント処理
    public void OnLook(InputValue value)
    {
        _inputLookValue = value.Get<Vector2>();
    }

    //=== inputAction [Attack]のイベント処理
    public void OnAttack(InputValue value)
    {
        _inputAttackValue = value.Get<float>();
    }
    
    
}
