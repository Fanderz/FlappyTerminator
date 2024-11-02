using UnityEngine;
using UnityEngine.Events;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private SpriteRenderer _renderer;

    public UnityEvent<BulletView> Collised;

    private void Start()
    {
        _renderer.sprite = _bullet.Sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 6 || collision.gameObject.layer != 7)
        {
            Collised?.Invoke(this);
            Collised.RemoveAllListeners();
        }
    }
}
