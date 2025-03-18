using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInput _input;
    private InputAction _moveAction;
    private Rigidbody2D _rb;

    [SerializeField]
    private float _maxSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _moveAction = _input.actions.FindAction("Movement");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.linearVelocity = _moveAction.ReadValue<Vector2>().normalized * _maxSpeed;
    }
}
