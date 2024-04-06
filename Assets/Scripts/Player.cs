using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 腳色的各種行為
/// </summary>
public class Player : MonoBehaviour
{
    public static Player instance;
    public Animator animator;
    new Rigidbody2D rigidbody;    
    new SpriteRenderer renderer;
    /// <summary>
    /// 計算移動用的參數
    /// </summary>
    Vector2 move;
    /// <summary>
    /// 可設定移動速度
    /// </summary>
    public float speed = 0.5f;

    [SerializeField] bool isIdle = false;

    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        rigidbody.velocity = speed * move;
        if(Mathf.Abs(move.x) < 0.05f && Mathf.Abs(move.y) < 0.05f && !isIdle) {
            // 腳色閒置時
            animator.Play("Idle");
            isIdle = true;
        }
    }
    /// <summary>
    /// 移動用的 SendMesseage()，當 WASD 被觸發時調用
    /// </summary>
    /// <param name="inputValue"></param>
    private void OnMove(InputValue inputValue) {
        if (isIdle) {
            animator.Play("Walk");
            isIdle = false;
        }
        move = inputValue.Get<Vector2>();
        if (move.x > 0) {
            renderer.flipX = false;
        }
        else if(move.x < 0) {
            renderer.flipX = true;
        }
    }
    /// <summary>
    /// 傳送用的 SendMesseage()，當 Space 被觸發時調用
    /// </summary>
    /// <param name="inputValue"></param>
    private void OnAction(InputValue inputValue) {
        if (!inputValue.isPressed) {
            return;
        }
        if (!target) {
            return;
        }

        if(target.tag == "Door") {
            // Door 標籤表示傳送點
            StageManager.lastone = StageManager.current;            
            StageManager.current = target.GetComponent<Door>().NextStage;
            switch (target.GetComponent<Door>().transition) {
                case TransitionType.Walk:
                    // 過場設定為腳步聲
                    StageManager.Instance.source.clip = StageManager.Instance.walk;
                    break;
                case TransitionType.Door:
                    // 過場設定為開門聲
                    StageManager.Instance.source.clip = StageManager.Instance.door;
                    break;
                default:
                    break;
            }
            StageManager.Instance.source.Play();
            // 下個舞台的腳色起始位置 (在 Hierachy中為子物件 Entry)
            transform.position = target.transform.GetChild(0).position;
            StageManager.lastone.SetActive(false);
            StageManager.current.SetActive(true);            
        }
    }
    /// <summary>
    /// 腳色走入傳送點
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other) {
        target = other.transform;
    }
    /// <summary>
    /// 腳色離開傳送點
    /// </summary>
    private void OnTriggerExit2D(Collider2D other) {
        if(target == other.transform) {
            target = null;
        }
    }
}
