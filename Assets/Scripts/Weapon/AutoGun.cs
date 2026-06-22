using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AutoGun : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //トリガーアクション(オーバーライド)
    public override void OnTriggerAction() 
    {
        Debug.Log("オートアクション");

        //弾丸の生成
        InstantiateBullet();

        //オートガンのトリガーアクションのロジックを追加
        base.OnTriggerAction();
    }
}
