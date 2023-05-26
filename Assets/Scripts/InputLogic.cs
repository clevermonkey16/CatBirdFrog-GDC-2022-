using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputLogic : MonoBehaviour
{
    public int stage = 1;
    public int selected = 1;
    public GameObject levelSelection;
    public GameObject crosshair;
    //public Animation levelSelectIn;

    
    public GameObject[] buttons = new GameObject[3];
    public Scene[] levels = new Scene[3];

    //1 = title screen, 2 = level select

    // Start is called before the first frame update
    void Start()
    {
        
        //levelSelectIn = levelSelection.GetComponent<Animation>();
    }

    void OnEnable()
    {
        //crosshair.transform.position = buttons[selected - 1].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == 1) {
            if (Input.GetKeyDown(KeyCode.C))
            {
                //enter level select
                stage = 2;
                levelSelection.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
            }
        }
        else if (stage == 2)
        {
            crosshair.transform.position = buttons[selected - 1].transform.position;

            if (Input.GetKeyDown(KeyCode.LeftArrow) && selected != 1)
            {
                selected--;
                
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && selected != 3)
            {
                selected++;
                
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                //enter level
                

                if(selected == 1)
                {
                    SceneManager.LoadScene("Movement_Prototype");
                }
                else if (selected == 2)
                {
                    SceneManager.LoadScene("lvl2");
                }
                else if (selected == 3)
                {
                    SceneManager.LoadScene("lvl3");
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                //back
                stage = 1;
                levelSelection.SetActive(false);
            }
        }
    }

    
}
