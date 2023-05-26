using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] int enemyLimit;

    GameObject[] enemies;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(timer > spawnInterval)
        {
            if(enemies.Length < enemyLimit)
            {
                //spawn enemy
                GameObject enemyClone = Instantiate(enemyPrefab);
                enemyClone.transform.position = new Vector3(Random.Range(-6, 6), Random.Range(-3.5f, 1.5f), 0);

                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
