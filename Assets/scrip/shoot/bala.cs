using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemy enemy = collision.GetComponent<enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("enemy2"))
        {
            enemy enemy = collision.GetComponent<enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("pared"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("pared"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 ||
            screenPosition.x > Camera.main.pixelWidth ||
            screenPosition.y < 0 ||
            screenPosition.y > Camera.main.pixelHeight)
        {
            Destroy(gameObject);
        }
    }




}
