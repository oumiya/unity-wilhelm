using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
   // スコア
    private int score;
    [SerializeField] UnityEngine.UI.Text scoretextbox;

    void Start()
    {
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
        score = score + point;
    }

}
