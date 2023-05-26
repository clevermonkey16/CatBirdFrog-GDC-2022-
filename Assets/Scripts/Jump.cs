using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;

    private Collision coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && coll.onGround)
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }

    
}
