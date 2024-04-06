using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public static Ghost Instance { get; private set; }
    public Image[] life = new Image[3];

    [SerializeField] int i = 2;

    float end;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (i < 0) {
            end += Time.deltaTime;
            if (end > 2.5f) {
                SceneController.instance.EnterScene("RESTART");
            }
        }
    }

    public void Show() {
        GetComponent<Animator>().Play("Jump");
        GetComponent<AudioSource>().Play();        
        life[i--].color = Color.black;        
    }
}
