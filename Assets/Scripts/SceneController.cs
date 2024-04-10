using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public GameObject audioMenu;
    GameObject clonedAudioMenu;
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
    public void InstanceAudioMenu()
    {
        clonedAudioMenu = Instantiate(audioMenu, FindObjectOfType<Canvas>().transform);
    }
    public void DestroyAudioMenu()
    {
        if(clonedAudioMenu != null)
        {
            Destroy(clonedAudioMenu);
        }
    }
}
