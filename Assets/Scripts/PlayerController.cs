using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float h;
    Rigidbody2D rb;

    public float speed = 5.0f;

    [Header("Collision")]
    public bool onGround = false;
    public float castLength;
    public LayerMask groundLayer;

    [SerializeField]
    private float jumpForce = 5.0f;

    [SerializeField] TextMeshPro healthTmp;
    [SerializeField] TextMeshPro scoreTmp;
    [SerializeField] int score = 0;
    [SerializeField] int health = 100;


    enum PlayerState
    {
        Idle,
        Run,
        Jump
    };

    PlayerState currentState;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        currentState = PlayerState.Idle;
    }


    float elapsed = 0f;
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");



        if (h > 0)
        {
            transform.localScale = new Vector3(
                System.Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(
                -System.Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z);
        }

        if (currentState == PlayerState.Jump)
        {
            
            if (rb.velocity.y < 0f && onGround)
            {
                anim.SetBool("isJump", false);
                if (h == 0)
                {
                    currentState = PlayerState.Idle;
                    anim.SetBool("isRun", false);
                }
                else
                {
                    currentState = PlayerState.Run;
                    anim.SetBool("isRun", true);
                }

            }
            
        }
        else if(currentState == PlayerState.Idle)
        {
            if (h != 0)
            {
                anim.SetBool("isRun", true);
                currentState = PlayerState.Run;
            }
        }
        else if(currentState == PlayerState.Run)
        {
            if (h == 0)
            {
                anim.SetBool("isRun", false);
                currentState = PlayerState.Idle;
            }
        }


        onGround = Physics2D.Raycast(transform.position, Vector2.down, castLength, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            currentState = PlayerState.Jump;
        }

        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            score += 1;
        }

        healthTmp.SetText("Health:{0}", health);
        scoreTmp.SetText("Score:{0}", score);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
    }
}
