using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float PlayerMovementSpeed = 10f;

    public bool IsShooting { get; private set; }
    private bool _moveForward;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

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
            var pointerWorldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, 0));
            var pointerWorld2DPosition = new Vector2(pointerWorldPosition.x, pointerWorldPosition.y);
            
            var playere2DPosition = new Vector2(transform.position.x, transform.position.y);
            var pointerToPlayerVector = pointerWorld2DPosition - playere2DPosition;
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
