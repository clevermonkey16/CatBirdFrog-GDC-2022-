using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    private Collision coll;
    private Rigidbody2D rb;
    [Range(1, 10)]
    public float jumpVelocity;

    public bool canOrb;

    // Start is called before the first frame update
    void Start()
    {
        jumpVelocity = GetComponent<playerControllerNew>().jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canOrb)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }

    public void SetCanOrb(bool b)
    {
        canOrb = b;
    }
}
