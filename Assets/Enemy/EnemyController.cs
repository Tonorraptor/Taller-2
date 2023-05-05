using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stoppingDistance = 2f;
    [SerializeField] private float retreatDistance = 1f;
    [SerializeField] private Transform player;

    private Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Si el jugador está demasiado lejos, el enemigo se mueve de manera aleatoria
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
        // Si el jugador está a una distancia adecuada, el enemigo se mueve hacia el jugador
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            movement = (player.position - transform.position).normalized;
        }
        // Si el jugador está demasiado cerca, el enemigo retrocede
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            movement = (transform.position - player.position).normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}
