using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private PlayerInput _input;
    private InputAction _interactAction;

    [SerializeField]
    private bool _canInteract = true;

    [ReadOnly]
    public bool InteractedThisFrame;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _interactAction = _input.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (_canInteract)
        {
            InteractedThisFrame = _interactAction.WasPressedThisFrame();
        }
    }
}
