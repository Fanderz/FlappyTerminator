using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet/Create new Bullet", order = 51)]
public class Bullet : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
    public float Speed => _speed;
}
