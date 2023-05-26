using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatButtonOnClick : MonoBehaviour
{

    public Image myImage;
    public Sprite catSprite1;
    public Sprite catSprite2;
    public Sprite catSprite3;
    int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        if (counter == 1)
        {
            counter = 2;
            myImage.sprite = catSprite2;
        }
        else if (counter == 2)
        {
            counter = 3;
            myImage.sprite = catSprite3;
        }
        else if(counter == 3)
        {
            counter = 1;
            myImage.sprite = catSprite1;
        }
    }
}
