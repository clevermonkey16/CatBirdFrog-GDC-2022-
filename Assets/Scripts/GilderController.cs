using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GilderController : MonoBehaviour
{

    private Collision coll;
    private Rigidbody2D rb;
    public bool isGliding = false;
    public float glideSpeed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!coll.onGround && Input.GetButton("Fire1") && rb.velocity.y<0)
        {
            isGliding = true;
            //GetComponent<BetterJump>().SetStopped(true);

            rb.velocity += Vector2.down * (glideSpeed + rb.velocity.y);
            anim.SetBool("isGlide", true);
        }
        else
        {
            isGliding = false;
            GetComponent<BetterJump>().SetStopped(false);
            anim.SetBool("isGlide", false);
        }
    }
}
