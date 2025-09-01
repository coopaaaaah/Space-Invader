using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    public Rigidbody2D ship;
    private InputAction _moveAction;
    private readonly int _moveSpeed = 5;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 direction =  _moveAction.ReadValue<Vector2>();
        if (_moveAction.inProgress && (IsLeftOrRightMovement(direction)))
        {
            ship.linearVelocity = direction * _moveSpeed;
        } else
        {
            ship.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ship.linearVelocity = Vector2.zero;
    }

    private static bool IsLeftOrRightMovement(Vector2 direction)
    {
        return direction.normalized == Vector2.left || direction.normalized == Vector2.right;
    }
}
