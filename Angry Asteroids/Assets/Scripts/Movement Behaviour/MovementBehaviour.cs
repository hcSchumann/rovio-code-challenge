using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float MovementSpeed = 100f;
    public MovementStrategy MovementStrategy;

    // Update is called once per frame
    void Update()
    {
        transform.position += MovementStrategy.GetMoveDirection() * Time.deltaTime * MovementSpeed;
    }
}
