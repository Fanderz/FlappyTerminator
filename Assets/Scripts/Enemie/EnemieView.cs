using UnityEngine;
using UnityEngine.Events;

public class EnemieView : MonoBehaviour
{
    [SerializeField] private Enemie _enemie;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private EnemieShooter _shooter;

    public EnemieShooter Shooter => _shooter;

    public UnityEvent<EnemieView> Collised;

    private void Start()
    {
        _renderer.sprite = _enemie.Sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Collised?.Invoke(this);
            Collised.RemoveAllListeners();
        }
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