using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    public GameObject worldLogic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            worldLogic.GetComponent<PlayerSwitch>().Respawn();
            //Debug.Log("Enter");
        }

    }
}
