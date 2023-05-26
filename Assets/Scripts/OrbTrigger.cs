using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger : MonoBehaviour
{

    public GameObject jumper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            jumper.GetComponent<JumperController>().SetCanOrb(true);
            //Debug.Log("Enter");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player") jumper.GetComponent<JumperController>().SetCanOrb(false);
    }
}
