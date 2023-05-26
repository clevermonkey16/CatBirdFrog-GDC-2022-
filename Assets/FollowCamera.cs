using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowCamera : MonoBehaviour
{

    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 10);
    }
}
