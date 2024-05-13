using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 鬼魂的各種行為
/// </summary>
public class Ghost : MonoBehaviour
{
    public static Ghost Instance { get; private set; }
    public Image[] life = new Image[3];
    public Animation shake;

    [SerializeField] int i = 2;

    /// <summary>
    /// 遊戲結束的 delay
    /// </summary>
    float delay;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (i < 0) {
            delay += Time.deltaTime;
            if (delay > 2.5f) {
                SceneController.instance.EnterScene("RESTART");
            }
        }
    }
    /// <summary>
    /// 召喚鬼魂 (Jump Scare)
    /// </summary>
    public void Show() {
        GetComponent<Animator>().Play("Jump");
        GetComponent<AudioSource>().Play();
        shake.Play();
        life[i--].color = Color.black;        
    }
}
