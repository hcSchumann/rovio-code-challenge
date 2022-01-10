using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public CircleCollider2D Collider;
    public GameObject VisualObject;
    public Vector3 Direction;

    public float size;
    public float Speed = 10;
    public int Power;
    public float LifeSpam;

    public void Start()
    {
        Collider.radius = size / 2;
        VisualObject.transform.localScale = new Vector3(size, size, 1);  
    }

    public void Update()
    {
        var deltaTime = Time.deltaTime;
        LifeSpam -= deltaTime;

        if(LifeSpam <= 0)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += Direction * deltaTime * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") return;

        Destroy(gameObject);
    }
}
