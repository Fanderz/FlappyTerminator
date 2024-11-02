using UnityEngine;

[CreateAssetMenu(fileName ="New Enemie", menuName ="Enemie/Create new Enemie", order = 51)]
public class Enemie : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
    public int Health => _health;
    public int Damage => _damage;
    public float Speed => _speed;
}
