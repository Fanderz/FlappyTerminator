using UnityEngine;
using System.Collections;

public class EnemieShooter : BaseShooter
{
    [SerializeField] private EnemyData _enemie;

    private Coroutine _shootingCoroutine;

    private void Awake()
    {
        Wait = new WaitForSeconds(ShootDelay);
    }

    private void OnEnable()
    {
        _shootingCoroutine = StartCoroutine(Shooting());
    }

    private void OnDisable()
    {
        if (_shootingCoroutine != null)
            StopCoroutine(_shootingCoroutine);
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            Shoot(Vector2.left, transform.rotation);

            yield return Wait;
        }
    }
}
