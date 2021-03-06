﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    // 初期化タイミングでインスタンスを生成
    private static readonly GameController mInstance = new GameController();

    public static int highScore;

    // コンストラクタをprivateにすることによって他クラスからnewできないようにする
    private GameController() { }

    // 他クラスからこのマネージャーを参照する
    public static GameController Instance
    {
        get
        {
            return mInstance;
        }
    }
    // FixedUpdateの間隔
    private readonly float FIXED_TIME_STEP = 0.03f;

    /// <summary>
    /// ゲームシステムを初期化する
    /// </summary>
    public void InitGame()
    {
        // 更新間隔の設定
        Time.fixedDeltaTime = FIXED_TIME_STEP;
    }


}