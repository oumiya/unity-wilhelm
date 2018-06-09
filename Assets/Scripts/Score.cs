using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
   // スコア
    private int score;
    private int score_magnification;//スコアの倍率設定用　ゲームオーバー時0倍で加算されなくする
    [SerializeField] UnityEngine.UI.Text scoretextbox;

    void Start()
    {
        score_magnification = 1;
        Initialize();
    }

    void Update()
    {
        scoretextbox.text = score.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point * score_magnification;
    }

    public void SetPointMagnification(int mag)
    {
        score_magnification = mag;
    }

}
