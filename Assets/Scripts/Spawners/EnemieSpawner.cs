using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : BaseSpawner<EnemieView>
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnPositionRate;
    [SerializeField] private Transform _upWall;
    [SerializeField] private Transform _ground;
    [SerializeField] private Transform _spawnXPosition;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private List<EnemieView> _prefabs;

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
            var enemmyprefab = _prefabs[randomIndexEnemyPrefab];

            var enemie = GetObject(enemmyprefab);

            if (enemie != null)
            {
                enemie.transform.position = new Vector2(_spawnXPosition.position.x, Random.Range(_ground.position.y + _spawnPositionRate, _upWall.position.y - _spawnPositionRate));
                enemie.Shooter.ShootingEventHandler.AddListener(_bulletSpawner.SpawnObject);
                enemie.Collised.AddListener(Release);

                Spawn(enemie);
            }

            yield return Wait;
        }
    }
}
