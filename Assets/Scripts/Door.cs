using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject NextScene;
    public TransitionType transition;
}

public enum TransitionType {
    Walk, Door
}