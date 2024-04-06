using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public static Ghost Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    public void Show() {
        GetComponent<Animator>().Play("Jump");
        GetComponent<AudioSource>().Play();
   }
}
