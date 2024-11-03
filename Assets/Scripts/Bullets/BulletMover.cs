using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private BulletData _bullet;

    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_bullet.Speed * Time.deltaTime * _direction);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}
