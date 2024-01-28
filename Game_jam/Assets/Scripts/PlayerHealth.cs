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
    [SerializeField] private int damageOnFall = 1;
    [SerializeField] private float deathYThreshold = -5.6f;

    // Store the position of the last checkpoint
    private Vector3 lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = max_health;
        lastCheckpoint = transform.position; // Initial checkpoint position
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player falls below the death Y threshold
        if (transform.position.y < deathYThreshold)
        {
            // Take damage on fall
            TakeDamage(damageOnFall);
        }
    }


    

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateLaughMeter((float)health / max_health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        // Restart the level after a delay
        Invoke("RestartLevel", 2f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    private void UpdateLaughMeter(float percentage)
    {
        laughMeterController.SetLaughMeterPercentage(percentage);
    }

}
