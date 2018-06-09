using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryModeButton : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("StoryScene");
    }
}
