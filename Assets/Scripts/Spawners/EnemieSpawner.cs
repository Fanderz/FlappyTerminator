using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : BaseSpawner<EnemyView>
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnPositionRate;
    [SerializeField] private Transform _upWall;
    [SerializeField] private Transform _ground;
    [SerializeField] private Transform _spawnXPosition;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private List<EnemyView> _prefabs;

    protected WaitForSeconds Wait;

    protected override void Awake()
    {
        base.Awake();
        Wait = new WaitForSeconds(_spawnDelay);

        Remover.ReleasingEnemie += Release;
    }

    private void Start()
    {
        SpawningCoroutine = StartCoroutine(Spawning());
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Remover.ReleasingEnemie -= Release;
    }

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            var randomIndexEnemyPrefab = Random.Range(0, _prefabs.Count);
            var enemyprefab = _prefabs[randomIndexEnemyPrefab];

            var enemyView = GetObject(enemyprefab);

            if (enemyView != null)
            {
                enemyView.transform.position = new Vector2(_spawnXPosition.position.x, Random.Range(_ground.position.y + _spawnPositionRate, _upWall.position.y - _spawnPositionRate));
                enemyView.Shooter.ShootingEventHandler.AddListener(_bulletSpawner.SpawnObject);

                var enemy = enemyView.GetComponent<Enemy>();
                enemy.Collised.AddListener(Release);

                Spawn(enemyView);
            }

            yield return Wait;
        }
    }
}
