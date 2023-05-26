using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform climber;
    public Transform glider;
    public Transform jumper;
    
    public int state = 1;

    //1=climber, 2=glider, 3=jumper;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1)
        {
            transform.position = new Vector3(climber.position.x + offset.x, climber.position.y + offset.y, offset.z);
        } else if (state == 2)
        {
            transform.position = new Vector3(glider.position.x + offset.x, glider.position.y + offset.y, offset.z);
        }
        else if (state == 3)
        {
            transform.position = new Vector3(jumper.position.x + offset.x, jumper.position.y + offset.y, offset.z);
        }


    }

    public void switchState()
    {
        if (state == 1) state = 2;
        else if (state == 2) state = 3;
        else if (state == 3) state = 1;
    }
    public void SetState(int n)
    {
        state = n;
    }
}
