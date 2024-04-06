using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Animator animator;
    Rigidbody2D rigidbody;    
    SpriteRenderer renderer;
    Vector2 move;
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
            animator.Play("Idle");
            isIdle = true;
        }
    }

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

    private void OnAction(InputValue inputValue) {
        if (!inputValue.isPressed) {
            return;
        }
        if (!target) {
            return;
        }

        if(target.tag == "Door") {
            StageManager.lastone = StageManager.current;            
            StageManager.current = target.GetComponent<Door>().NextScene;
            switch (target.GetComponent<Door>().transition) {
                case TransitionType.Walk:
                    StageManager.Instance.source.clip = StageManager.Instance.walk;
                    break;
                case TransitionType.Door:
                    StageManager.Instance.source.clip = StageManager.Instance.door;
                    break;
                default:
                    break;
            }
            StageManager.Instance.source.Play();
            transform.position = target.transform.GetChild(0).position;
            StageManager.lastone.SetActive(false);
            StageManager.current.SetActive(true);            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        target = other.transform;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(target == other.transform) {
            target = null;
        }
    }
}
