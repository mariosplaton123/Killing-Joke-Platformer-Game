using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed;
    [SerializeField] private int patrolDestination;
    public Transform playerTransform;
    private bool isChasing;
    [SerializeField] private float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {
        sprite=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
            sprite.flipX = (playerTransform.position.x < transform.position.x);
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
                {
                    sprite.flipX = true;
                    patrolDestination = 1;
                }
            }
            else if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
                {
                    sprite.flipX = false;
                    patrolDestination = 0;
                }
            }
        }
    }
}
