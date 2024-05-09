using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Transform spawnPoint;

    public float health;
    public float maxHealth;
    public float healingRate;

    public HealthBar healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (health<maxHealth)
        {
            health += healingRate * Time.deltaTime;
            healthBar.SetHealth(health);
        }
    }

    public void RestoreAllHealth()
    {
        health = maxHealth;
        healthBar.SetHealth(health);
    }

    public void RestoreHealth(float healing)
    {
        if (health < maxHealth)
        {
            health += healing;
            healthBar.SetHealth(health);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            transform.position = spawnPoint.position;
            RestoreAllHealth();
        }
    }
}
