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
        var bullet = GetObject(bulletViewPrefab);

        if (bullet != null)
        {
            bullet.transform.position = startPosition.position;
            bullet.Collised.AddListener(Release);

            var mover = bullet.GetComponent<BulletMover>();
            mover.transform.rotation = rotation;
            mover.SetDirection(direction);

            Spawn(bullet);
        }
    }
}
