using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pointable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler {
    public int keyIndex = 0;
    public bool byColor = false;
    [SerializeField] bool hasDone = false;

    public void Revive() {
        hasDone = false;
        if (byColor) {
            GetComponent<Image>().color = Color.white;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        hasDone = true;
        if (byColor) {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
        transform.localScale = 0.8f * transform.localScale;
        if(tag == "Ghost") {
            Ghost.Instance.Show();
            Player.instance.animator.SetTrigger("DieForward");
        }
        if(tag == "Key") {
            QuestionController.instance.TriggerQuestion(keyIndex);
            QuestionController.instance.currentItem = this;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (hasDone) {
            return;
        }
        transform.localScale = 1.25f * transform.localScale;
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (hasDone) {
            return;
        }
        transform.localScale = 0.8f * transform.localScale;
    }
}
