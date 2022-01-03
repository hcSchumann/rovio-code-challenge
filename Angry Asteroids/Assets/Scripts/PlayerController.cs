using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float PlayerMovementSpeed = 10f;

    private Vector3 _currentInput;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += _currentInput * Time.deltaTime * PlayerMovementSpeed;
    }

    public void OnPlayerMoved(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            var playerInput = context.ReadValue<Vector2>();
            _currentInput = new Vector3(playerInput.x, playerInput.y, 0);
        }
        else if(context.canceled)
        {
            _currentInput = Vector3.zero;
        }
    }
}
