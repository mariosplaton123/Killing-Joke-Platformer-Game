using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int max_health = 4;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void TakeDamage(int damage){
        health -= damage;
        if(health<=0){
            Debug.Log("Died!");
        }
    }
}
