using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed;
    [SerializeField] private int patrolDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolDestination == 0){
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f){
                patrolDestination = 1;
            }
        }
        else if (patrolDestination == 1){
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[1].position) < .2f){
                patrolDestination = 0;
             }
        }
    }
}
