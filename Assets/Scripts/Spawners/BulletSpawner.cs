using UnityEngine;

public class BulletSpawner : BaseSpawner<BulletView>
{
    protected override void Awake()
    {
        base.Awake();

        Remover.ReleasingBullet += Release;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Remover.ReleasingBullet -= Release;
    }

    public void SpawnObject(BulletView bulletViewPrefab, Transform startPosition, Vector2 direction, Quaternion rotation)
    {
        var bulletView = GetObject(bulletViewPrefab);

        if (bulletView != null)
        {
            bulletView.transform.position = startPosition.position;

            var bullet = bulletView.GetComponent<Bullet>();
            bullet.Collised.AddListener(Release);

            var mover = bulletView.GetComponent<BulletMover>();
            mover.transform.rotation = rotation;
            mover.SetDirection(direction);

            Spawn(bulletView);
        }
    }
}
