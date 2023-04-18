using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigigBody;
    private PlayerAwareneesController _playerAwareneesController;
    private Vector2 _targetDirection;

    private void Awake()
    {
        _rigigBody = GetComponent<Rigidbody2D>();
        _playerAwareneesController = GetComponent<PlayerAwareneesController>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwareneesController.AwareOfPlayer)
        {
            _targetDirection = _playerAwareneesController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigigBody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if(_targetDirection == Vector2.zero)
        {
            _rigigBody.velocity = Vector2.zero;
        }
        else
        {
            _rigigBody.velocity = transform.up * _speed;

        }
    }

}
