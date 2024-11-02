using UnityEngine;
using UnityEngine.Events;

public class BaseShooter : MonoBehaviour
{
    [SerializeField] protected float ShootDelay;
    [SerializeField] protected BulletView _bulletViewPrefab;

    protected WaitForSeconds Wait;
    public UnityEvent<BulletView, Transform, Vector2, Quaternion> ShootingEventHandler;

    protected void Shoot(Vector2 direction, Quaternion rotation)
    {
        ShootingEventHandler?.Invoke(_bulletViewPrefab, transform, direction, rotation);
    }
}
