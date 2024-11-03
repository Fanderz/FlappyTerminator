using UnityEngine;
using UnityEngine.Events;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyData _enemie;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private EnemieShooter _shooter;

    public EnemieShooter Shooter => _shooter;

    private void Start()
    {
        _renderer.sprite = _enemie.Sprite;
    }

    private void OnDisable()
    {
        _shooter.ShootingEventHandler.RemoveAllListeners();
    }

    private void OnValidate()
    {
        if (_shooter == null)
        {
            var child = transform.GetChild(0);

            if (child != null)
                _shooter = child.GetComponent<EnemieShooter>();
        }
    }
}