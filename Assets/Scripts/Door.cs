using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour
{
    [Tooltip("下一個舞台"), FormerlySerializedAs("NextScene")]
    public GameObject NextStage;
    [Tooltip("過場音效")]
    public TransitionType transition;
}

public enum TransitionType {
    Walk, Door
}