using UnityEngine;

public class BirdShooter : BaseShooter
{
    [SerializeField] private BirdRotation _birdRotation;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void Start()
    {
        ShootingEventHandler.AddListener(_bulletSpawner.SpawnObject);
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot(Vector2.right, _birdRotation.transform.rotation);
        }
    }

    private void OnDisable()
    {
        ShootingEventHandler.RemoveAllListeners();
    }
}
