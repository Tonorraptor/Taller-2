using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemy : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí iría cualquier efecto visual o sonoro de la muerte del enemigo.
        Destroy(gameObject);
    }
}
