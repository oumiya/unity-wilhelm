using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotation : MonoBehaviour {
    private Vector2 prev; //前回の座標保持

    // Use this for initialization
    void Start () {
        prev = transform.position; //前回の座標初期化
    }

    // Update is called once per frame
    void Update () {
        Vector2 diff = transform.position;//前回の座標と現在の座標から方向を求める
        diff = diff - prev;
        if (diff.magnitude > 0.01)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, diff);
        }
        prev = transform.position;
    }
}
//参考元   http://d.hatena.ne.jp/nakamura001/20130718/1374175612
//         http://tsubakit1.hateblo.jp/entry/2017/07/02/232453
