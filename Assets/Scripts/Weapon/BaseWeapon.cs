using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [Header("***Base Setting***")]
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected GameObject _shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //トリガーアクション
    public virtual void OnTriggerAction() 
    {
        
    }

    protected void InstantiateBullet()
    {
        //弾丸の生成
        GameObject bullet = Instantiate(
            _bulletPrefab,                             //生成オブジェクト
            _shotPoint.transform.position,             //生成位置
            Quaternion.identity                        //生成角度
        );

        //弾丸の発射
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Camera.main.transform.forward * 50f, ForceMode.Impulse);

        Destroy(bullet, 5f);                           //n秒後に消失
    }
}
