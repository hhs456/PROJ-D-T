using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake() {
        instance = this;
    }
    /// <summary>
    /// 進入場景
    /// </summary>
    /// <param name="name"></param>
    public void EnterScene(string name) {
        SceneManager.LoadScene(name);
    }
    /// <summary>
    /// 關閉遊戲
    /// </summary>
    public void Quit() {
        Application.Quit();
    }
}
