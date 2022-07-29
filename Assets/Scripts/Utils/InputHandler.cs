using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Input = GameInput.Input;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent <InputAction.CallbackContext> _jump; 
    private Input _input;

    private void Awake()
    {
        _input = new Input();
        _input.Enable();
    }
    
    private void OnEnable()
    {
        _input.Bird.Jump.performed += _jump.Invoke;
    }

    private void OnDisable()
    {
        _input.Bird.Jump.performed -= _jump.Invoke;
    }
}
