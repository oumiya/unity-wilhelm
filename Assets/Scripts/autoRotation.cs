using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour {
    private Vector2 prev; //前回の座標保持
    private enum ArrowStatus { Flyng, Hits};
    private ArrowStatus arrowState;
    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start () {
        prev = transform.position; //前回の座標初期化
        arrowState = ArrowStatus.Flyng;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        if (arrowState == ArrowStatus.Flyng)
        {
            // 矢の自動回転
            Vector2 diff = transform.position;//前回の座標と現在の座標から方向を求める
            diff = diff - prev;
            if (diff.magnitude > 0.01)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, diff);
            }
            prev = transform.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        arrowState = ArrowStatus.Hits;
        rigidbody2D.simulated = false;
        Player player = GameObject.Find("player").GetComponent<Player>();
    }
}
//参考元   http://d.hatena.ne.jp/nakamura001/20130718/1374175612
//         http://tsubakit1.hateblo.jp/entry/2017/07/02/232453
