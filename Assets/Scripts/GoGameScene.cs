using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// ストーリーモードをクリックしたらストーリーモードへシーンを遷移
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("StoryScene");
        }

        // 打ち放題モードをクリックしたら打ち放題モードへシーンを遷移
	}
}
