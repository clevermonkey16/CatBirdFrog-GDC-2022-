using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            //randX = Random.Range(-8.4f, 8.4f);
            whereToSpawn = new Vector2(0, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
    public void OpenMessagePanel(string text)
    {
        // message.SetActive(true);
    }
    public void CloseMessagePanel()
    {
        //   message.SetActive(false);
    }
}
