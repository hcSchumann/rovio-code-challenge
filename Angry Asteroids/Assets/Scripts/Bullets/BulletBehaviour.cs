using UnityEngine;
using System;
public class BulletBehaviour : MonoBehaviour
{
    public CircleCollider2D Collider;
    public GameObject VisualObject;
    public Vector3 Direction;
    public Action<GameObject> OnBulletDie;

    public float Size 
    { 
        get { return _size; } 
        set
        {
            _size = value;
            UpdateSize();
        }
    }
    public float Speed = 10;
    public int Power;
    public float LifeSpam;

    private float _size = 5;
    public void Start()
    {
        UpdateSize();
    }

    public void Update()
    {
        var deltaTime = Time.deltaTime;
        LifeSpam -= deltaTime;

        if(LifeSpam <= 0)
        {
            Die();
            return;
        }

        transform.position += Direction * deltaTime * Speed;
    }

    private void UpdateSize()
    {
        Collider.radius = _size / 2;
        VisualObject.transform.localScale = new Vector3(_size, _size, 1);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") return;
        other.gameObject.GetComponent<Health>().DecreaseHealth(Power);
        Die();
    }

    private void Die()
    {
        if(OnBulletDie == null)
        {
            Destroy(gameObject);
            return;
        }

        OnBulletDie.Invoke(gameObject);
    }
}
