using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    private enum STATE
    {
        INIT = 0,
        PLAY,
        GAME_OVER
    };
    private STATE mState = STATE.INIT;
    private float timer = 30.0f;
    private string timtxt;
    private float score;
    [SerializeField] UnityEngine.UI.Text timetextbox;
 
    void Update()
    {
        switch (mState)
        {
            case STATE.INIT:
                // 初期化処理
 
                mState = STATE.PLAY;
                break;
            case STATE.PLAY:
                // プレイ中
                if (SceneManager.GetActiveScene().name == "ScoreAttackScene")
                {
                    if (timer > 0.0f)
                    {
                        timer -= Time.deltaTime;
                        timtxt = timer.ToString("F");
                        timetextbox.text = timtxt;
                    }
                    else
                    {
                        timer = 0.0f;
                        timtxt = timer.ToString("F");
                        timetextbox.text = timtxt;
                        FindObjectOfType<Score>().SetPointMagnification(0);
                        mState = STATE.GAME_OVER;
                        timer = 5.0f;
                    }
                };
                break;
            case STATE.GAME_OVER:
                // ゲームオーバー
                if (timer > 0.0f)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    SceneManager.LoadScene("TitleScene");
                }

                break;
        }
    }
    private GameController mGame;

    void Awake()
    {
        mGame = GameController.Instance;
        mGame.InitGame();
    }
}