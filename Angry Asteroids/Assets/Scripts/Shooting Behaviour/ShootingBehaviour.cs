using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField]
    public ShootingStrategy ShootingStrategy;
    private Transform _target;

    public void Awake()
    {
        if(ShootingStrategy == null)
        {
            ShootingStrategy = new PlayerShootingStrategy();
        }
    }

    public void Start()
    {
        _target = ShootingStrategy.AcquireTarget();
    }

    public void Update()
    {
        if(ShootingStrategy.CanShoot(transform, _target))
        {
            ShootingStrategy.ExecuteShoot(transform, _target);
        }
    }
}
