using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 5f;
    public float range = 5f;
    public float stoppingDistance = 1f;
    public LayerMask obstacleMask;
    public int health;

    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Solo seguir al jugador si está en rango y no hay obstáculos en el camino
        Vector3 direction = player.position - transform.position;
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < range && !Physics2D.Raycast(transform.position, direction.normalized, distance, obstacleMask))
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damage)
    {
        // Restar la cantidad de daño a la vida del enemigo
        health -= damage;

        // Si la salud del enemigo llega a cero o menos, destruir el objeto
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
