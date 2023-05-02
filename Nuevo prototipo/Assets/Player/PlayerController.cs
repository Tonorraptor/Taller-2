using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float move_speed = 80f;
    private const float dash_speed = 450f;
    private const float dash_time = 0.1f;
    private float dash_timer;

    public Camera cam;

    [SerializeField] private LayerMask dashLayerMask;

    private new Rigidbody2D rigidbody2D;

    private Vector3 moveDir;
    private Vector2 mousePos;
    private Vector2 movement;

    private bool isDashButtonDown;
    private bool isDashing;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        moveDir = new Vector3(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            isDashButtonDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            movement = new Vector2(moveDir.x * move_speed, moveDir.y * move_speed);
            rigidbody2D.MovePosition(rigidbody2D.position + movement * Time.fixedDeltaTime);

            Vector2 lookDir = mousePos - rigidbody2D.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rigidbody2D.rotation = angle;

            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            rigidbody2D.velocity = moveDir * dash_speed;
            dash_timer -= Time.fixedDeltaTime;
            if (dash_timer <= 0)
            {
                isDashing = false;
            }
        }

        if (isDashButtonDown)
        {
            isDashing = true;
            dash_timer = dash_time;
            float dashAmount = 50f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }

            rigidbody2D.MovePosition(dashPosition);
            isDashButtonDown = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
