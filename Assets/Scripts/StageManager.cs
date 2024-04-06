using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public static GameObject current;
    public static GameObject lastone;

    public AudioSource source;
    public AudioClip walk;
    public AudioClip door;

    public GameObject initial;

    private void Awake() {
        current = initial;
        Instance = this;
    }
}
