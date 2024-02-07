using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int damage = 1;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag ("Player")){
            playerMovement.KBcounter = playerMovement.KBtotalTime;
            if (other.transform.position.x <= transform.position.x){
                playerMovement.KnockFromRight = true;
            }
            if (other.transform.position.x > transform.position.x){
                playerMovement.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
            Debug.Log("Damage!");
            
        }
    }
}
