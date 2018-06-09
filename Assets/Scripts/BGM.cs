using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour {

    enum BgmStatus { Ambient, Finished, GameOver };
    BgmStatus bgmState;

	// Use this for initialization
	void Start () {
        GameObject clear = GameObject.Find("clear");
        clear.GetComponent<Renderer>().enabled = false;

        GameObject win_text = GameObject.Find("win_text");
        win_text.GetComponent<Renderer>().enabled = false;

        GameObject game_over = GameObject.Find("game_over");
        game_over.GetComponent<Renderer>().enabled = false;

        GameObject lose_text = GameObject.Find("lose_text");
        lose_text.GetComponent<Renderer>().enabled = false;

        bgmState = BgmStatus.Ambient;
    }
	
	// Update is called once per frame
	void Update () {
        if (bgmState == BgmStatus.Finished)
        {
            AudioSource[] bgm = GetComponents<AudioSource>();
            if (!bgm[1].isPlaying)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        if (bgmState == BgmStatus.GameOver)
        {
            AudioSource[] bgm = GetComponents<AudioSource>();
            if (!bgm[2].isPlaying)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    public void FinishBGM()
    {
        AudioSource[] bgm = GetComponents<AudioSource>();
        bgm[0].Stop();
        bgm[1].Play();
        bgmState = BgmStatus.Finished;
    }

    public void GameOverBGM()
    {
        AudioSource[] bgm = GetComponents<AudioSource>();
        bgm[0].Stop();
        bgm[2].Play();
        bgmState = BgmStatus.GameOver;
    }
}
