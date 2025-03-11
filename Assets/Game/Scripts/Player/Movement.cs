using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInput _input;
    private InputAction _movementAction;
    private Vector2 _movement;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _input = GetComponent<PlayerInput>();
        _movementAction = _input.actions.FindAction("Movement");
    }

    private void OnEnable()
    {
        _movementAction.started += OnMoveInput;
        _movementAction.canceled += OnMoveInput;
    }

    private void OnDisable()
    {
        _movementAction.started -= OnMoveInput;
        _movementAction.canceled -= OnMoveInput;
    }

    private void Update()
    {
        Move();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Debug.Log(_movement);
        _movement = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        _rb.AddForce(_movement, ForceMode2D.Force);
    }
}
