using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float EnemySpeed;
    Rigidbody2D rb;
    Vector3 startPos;
    GameObject player;

    enum EnemyState
    {
        Idle,
        Activated,
        Return,
        Die
    };

    EnemyState currentState;
    


    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.Idle;
        rb = this.GetComponent<Rigidbody2D>();
        startPos = transform.position;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentState == EnemyState.Idle)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        else if (currentState == EnemyState.Activated)
        {
            Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            EnemyMove(moveDirection);

        }
        else if (currentState == EnemyState.Die)
        {


        }
        else if (currentState == EnemyState.Return)
        {

            Vector3 moveDirection = (startPos - transform.position).normalized;
            EnemyMove(moveDirection);

            if (Vector3.Distance(transform.position, startPos) < 0.05)
            {
                currentState = EnemyState.Idle;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            currentState = EnemyState.Activated;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
            currentState = EnemyState.Return;
        }
    }

    void EnemyMove(Vector3 direction)
    {
        rb.velocity = new Vector2(direction.x, direction.y);
    }

}

