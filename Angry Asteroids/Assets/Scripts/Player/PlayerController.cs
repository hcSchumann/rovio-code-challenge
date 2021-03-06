using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float PlayerMovementSpeed = 100f;
    public Camera MainCamera;

    public bool IsShooting { get; private set; }
    private bool _moveForward;

    void Update()
    {
        if(_moveForward)
        {
            transform.position += transform.right * Time.deltaTime * PlayerMovementSpeed;
        }
    }

    public void OnPlayerMoved(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _moveForward = true;
        }
        else if(context.canceled)
        {
            _moveForward = false;
        }
    }

    public void OnMouseMoved(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var pointerPosition = context.ReadValue<Vector2>();
            var pointerWorldPosition = MainCamera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, 0));
            var pointerWorld2DPosition = new Vector2(pointerWorldPosition.x, pointerWorldPosition.y);
            
            var player2DPosition = new Vector2(transform.position.x, transform.position.y);
            var pointerToPlayerVector = pointerWorld2DPosition - player2DPosition;
            var newRight = new Vector3(pointerToPlayerVector.x, pointerToPlayerVector.y, 0);
            
            transform.right = newRight.normalized;
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsShooting = true;
        }
        else if (context.performed)
        {
            IsShooting = true;
        }
        else if (context.canceled)
        {
            IsShooting = false;
        }
    }
}
