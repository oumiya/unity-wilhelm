using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 矢
/// </summary>
/// <remarks>
/// 参考
/// http://d.hatena.ne.jp/nakamura001/20130718/1374175612
/// http://tsubakit1.hateblo.jp/entry/2017/07/02/232453
/// </remarks>
public class Arrow : MonoBehaviour {
    private Vector2 prev; //前回の座標保持
    private enum ArrowStatus { Flyng, Hits };
    private ArrowStatus arrowState;
    private Rigidbody2D rigidbody2D;
    public GameObject blood;
    public GameObject paper;

    // Use this for initialization
    void Start () {
        prev = transform.position; //前回の座標初期化
        arrowState = ArrowStatus.Flyng;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		// オブジェクトが描画されなくなったらデストロイ
        if (!GetComponent<Renderer>().isVisible)
        {
            if (arrowState == ArrowStatus.Flyng)
            {
                Player player = GameObject.Find("player").GetComponent<Player>();
                player.SetStateReload();
            }
            Destroy(this.gameObject);
        }

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
        player.SetStateReload();

        if (collision.gameObject.tag.Equals("Son"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);

            if (SceneManager.GetActiveScene().name == "StoryScene")
            {
                BGM bgm = GameObject.Find("BGM").GetComponent<BGM>();
                bgm.GameOverBGM();
                player.SetStateFreeze();

                GameObject game_over = GameObject.Find("game_over");
                game_over.GetComponent<Renderer>().enabled = true;

                GameObject lose_text = GameObject.Find("lose_text");
                lose_text.GetComponent<Renderer>().enabled = true;
            }

            return;
        }

        if (collision.gameObject.tag.Equals("Apple"))
        {
            if (SceneManager.GetActiveScene().name == "ScoreAttackScene")
            {
                if (collision.gameObject.tag.Equals("Apple"))
                {
                    FindObjectOfType<Score>().AddPoint(100);
                }
                if (collision.gameObject.tag.Equals("Son"))
                {
                    FindObjectOfType<Score>().AddPoint(1);
                }
            }

            if (SceneManager.GetActiveScene().name == "StoryScene")
            {

                BGM bgm = GameObject.Find("BGM").GetComponent<BGM>();
                bgm.FinishBGM();
                Instantiate(paper, new Vector3(-5.8f, 4.8f, -9.8f), Quaternion.identity);
                Instantiate(paper, new Vector3(-2.8f, 4.8f, -9.8f), Quaternion.identity);
                Instantiate(paper, new Vector3(0f, 4.8f, -9.8f), Quaternion.identity);
                Instantiate(paper, new Vector3(3f, 4.8f, -9.8f), Quaternion.identity);
                Instantiate(paper, new Vector3(6f, 4.8f, -9.8f), Quaternion.identity);
                player.SetStateFreeze();

                GameObject clear = GameObject.Find("clear");
                clear.GetComponent<Renderer>().enabled = true;

                GameObject win_text = GameObject.Find("win_text");
                win_text.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
