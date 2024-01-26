using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int max_health = 4;
    private int health;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private LaughMeterController laughMeterController;
    [SerializeField] float deathYThreshhold = -5.6f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deathYThreshhold){
            Die();
        }
    }

    public  void TakeDamage(int damage){
        health -= damage;
        float laughMeterPercentage = Mathf.Clamp01((float)health / max_health);
        laughMeterController.SetLaughMeterPercentage(laughMeterPercentage);
        if(health<=0){
            Die();
        }
    }
    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        Invoke("RestartLevel", 2f);
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
