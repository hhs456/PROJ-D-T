using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 舞台管理器
/// </summary>
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public static GameObject current;
    public static GameObject lastone;

    public AudioSource BGM;

    /// <summary>
    /// 播放過場音效的來源
    /// </summary>
    public AudioSource source;
    /// <summary>
    /// 腳步聲
    /// </summary>
    public AudioClip walk;
    /// <summary>
    /// 開門聲
    /// </summary>
    public AudioClip door;
    /// <summary>
    /// 起始場景
    /// </summary>
    public GameObject initial;

    private void Awake() {
        current = initial;
        Instance = this;
        BGM.PlayDelayed(5f);
    }
}
