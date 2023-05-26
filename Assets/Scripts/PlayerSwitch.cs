using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject climber;
    public GameObject glider;
    public GameObject jumper;

    public Camera gameCamera;

    public int state = 1;

    public GameObject spawn;
    

    //1=climber, 2=glider, 3=jumper;

    // Start is called before the first frame update
    void Start()
    {
        playerSwitch();
    }

    // Update is called once per frame
    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.X))
        {

            //switch state
            if (state == 1) state = 2;
            else if (state == 2) state = 3;
            else if (state == 3) state = 1;

            //change player
            playerSwitch();

            //particle animation


            //switch camera
            gameCamera.GetComponent<FollowPlayer>().switchState();

            //slowmo
            StartCoroutine(Slowmo());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScreen");
        }

            
    }

    IEnumerator Slowmo()
    {
        for (float alpha = 2f; alpha >= 0; alpha -= 1f)
        {
            //Time.timeScale = 0.5f;
            yield return new WaitForSeconds(.1f);
        }
        Time.timeScale = 1;
    }

    public void Respawn()
    {


        if (state == 1)
        {
            climber.GetComponent<playerControllerNew>().StartRespawn(spawn.transform);
        }
        else if (state == 2)
        {
            glider.GetComponent<playerControllerNew>().StartRespawn(spawn.transform);
        }
        else if (state == 3)
        {
            jumper.GetComponent<playerControllerNew>().StartRespawn(spawn.transform);
        }
        state = 1;
        
    }

    public void playerSwitch()
    {
        if (state == 1)
        {
            climber.SetActive(true);
            glider.SetActive(false);
            jumper.SetActive(false);

            climber.transform.position = new Vector3(jumper.transform.position.x, jumper.transform.position.y, 0);
        }
        else if (state == 2)
        {
            climber.SetActive(false);
            glider.SetActive(true);
            jumper.SetActive(false);

            glider.transform.position = new Vector3(climber.transform.position.x, climber.transform.position.y, 0);
        }
        else if (state == 3)
        {
            climber.SetActive(false);
            glider.SetActive(false);
            jumper.SetActive(true);

            jumper.transform.position = new Vector3(glider.transform.position.x, glider.transform.position.y, 0);
        }
    }

    public void spawnActivate()
    {
        climber.SetActive(true);
        glider.SetActive(false);
        jumper.SetActive(false);
        climber.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
        state = 1;
    }
}
