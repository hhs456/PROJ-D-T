using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 可以互動的 UI 物件
/// </summary>
public class Pointable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler {
    public int keyIndex = 0;
    public bool byColor = false;
    [SerializeField] bool hasDone = false;
    
    /// <summary>
    /// 答錯時恢復物品的可互動狀態
    /// </summary>
    public void Revive() {
        hasDone = false;
        if (byColor) {
            GetComponent<Image>().color = Color.white;
        }
    }
    /// <summary>
    /// 點擊物品時的互動
    /// </summary>
    /// <param name="eventData"></param>
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
    /// <summary>
    /// 滑鼠進入可互動範圍
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData) {
        if (hasDone) {
            return;
        }
        transform.localScale = 1.25f * transform.localScale;
    }
    /// <summary>
    /// 滑鼠離開可互動範圍
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData) {
        if (hasDone) {
            return;
        }
        transform.localScale = 0.8f * transform.localScale;
    }
}
