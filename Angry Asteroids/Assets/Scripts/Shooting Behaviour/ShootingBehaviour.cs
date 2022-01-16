using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField]
    public ShootingStrategy ShootingStrategy;
    private Transform _target;

    public void Start()
    {
        if (ShootingStrategy == null)
        {
            this.enabled = false;
            return;
        }

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
