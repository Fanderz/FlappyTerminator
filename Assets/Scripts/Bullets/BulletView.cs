using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private BulletData _bullet;
    [SerializeField] private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer.sprite = _bullet.Sprite;
    }
}
