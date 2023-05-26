using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishline : MonoBehaviour
{
    public GameObject completionText;
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObj = collision.gameObject;
        if(hitObj.tag == "Player")
        {
            StartCoroutine(WinSequence());
        }
    }

    IEnumerator WinSequence()
    {
        completionText.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TitleScreen");
        
    }
}
