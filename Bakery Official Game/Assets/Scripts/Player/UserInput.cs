using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{    
    public Vector2 MoveInput {  get; private set; }

    private PlayerInput _playerInput;

    private InputAction _moveAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions["Move"];
    }

    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
    }
}
