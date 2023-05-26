using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerNew : MonoBehaviour
{
    

    private Collision coll;
    private Rigidbody2D rb;

    
    [Header("Stats")]
    public float speed = 10f;
    public float slideSpeed = 5f;
    public float jumpForce = 50f;
    public float wallJumpLerp = 10;


    [Header("Booleans")]
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;

    public int side = 1;

    public bool isClimber;
    public GameObject worldLogic;
    public Camera gameCamera;

    enum PlayerState
    {
        Idle,
        Run,
        Jump
    };

    PlayerState currentState;
    Animator anim;

    //public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        anim = this.GetComponent<Animator>();

        currentState = PlayerState.Idle;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        if(canMove) Walk(dir);
        //anim.Play("PlayerIdle");

        if (coll.onWall && Input.GetKey(KeyCode.Z) && canMove && isClimber)
        {
            /*
            if (side != coll.wallSide)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                side *= -1;
            }
            */
            
            wallGrab = true;
            wallSlide = false;
        }

        if (Input.GetKeyUp(KeyCode.Z) || !coll.onWall || !canMove)
        {
            wallGrab = false;
            wallSlide = false;
        }

        if (coll.onGround && !isDashing)
        {
            wallJumped = false;
            GetComponent<BetterJump>().enabled = true;
        }

        if (wallGrab && !isDashing)
        {
            rb.gravityScale = 0;
            if (x > .2f || x < -.2f)
                rb.velocity = new Vector2(rb.velocity.x, 0);

            float speedModifier = y > 0 ? .5f : 1;

            rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
            anim.SetBool("isClimb", true);
        }
        else
        {
            rb.gravityScale = 1;
            anim.SetBool("isClimb", false);
        }



        if (coll.onWall && !coll.onGround && !wallGrab && x != 0 && x * coll.wallSide < 0)
        {
            wallSlide = true;
            WallSlide();
            if (true)
            {

            } //else wallSlide = false;
        }
        else
        {
            wallSlide = false;
            //Debug.Log("stopped");
        }

        //if (!coll.onWall || coll.onGround) wallSlide = false;



        if (Input.GetButtonDown("Jump"))
        {
            //anim.SetTrigger("jump");

            if (coll.onGround)
            {
                Jump(Vector2.up, false);
                currentState = PlayerState.Jump;
                anim.SetBool("isJump", true);
            }

            if (coll.onWall && !coll.onGround)
            {
                WallJump();
                currentState = PlayerState.Jump;
                anim.SetBool("isJump", true);
            }
        }

        if (coll.onGround && rb.velocity.y <= 0) anim.SetBool("isJump", false);


        if (x > 0)
        {
            if (side == -1)
            {
                //flip
                Vector3 theScale = transform.localScale;
                theScale.x = Mathf.Abs(theScale.x);
                transform.localScale = theScale;
            }
            side = 1;
            currentState = PlayerState.Run;
            //anim.Flip(side);
            anim.SetBool("isRun", true);
        }
        else if (x < 0)
        {
            if (side == 1)
            {
                //flip
                Vector3 theScale = transform.localScale;
                theScale.x = Mathf.Abs(theScale.x) * -1;
                transform.localScale = theScale;
            }
            side = -1;
            currentState = PlayerState.Run;
            //anim.Flip(side);
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

    }
        

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
    }

    private void WallJump()
    {
        if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
        {
            side *= -1;
            //anim.Flip(side);
        }

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up / 1.5f + wallDir / 1.5f), true);

        wallJumped = true;
    }

    private void Jump(Vector2 dir, bool wall)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }

    private void WallSlide()
    {
        //if (!canMove) return;

        rb.velocity = new Vector2(0, -slideSpeed);
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    IEnumerator Respawn()
    {
        //play animation
        

        for (float alpha = 5f; alpha >= 0; alpha -= 1f)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            canMove = false;
            GetComponent<BetterJump>().enabled = false;
            yield return new WaitForSeconds(.1f);
        }

        canMove = true;
        rb.gravityScale = 1;
        GetComponent<BetterJump>().enabled = true;

        //this.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        worldLogic.GetComponent<PlayerSwitch>().spawnActivate();

        gameCamera.GetComponent<FollowPlayer>().SetState(1);
        
        
    }

    public void StartRespawn(Transform t)
    {
        StartCoroutine(Respawn());
    }


}
