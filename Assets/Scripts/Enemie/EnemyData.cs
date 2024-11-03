using UnityEngine;

[CreateAssetMenu(fileName ="New Enemie", menuName ="Enemie/Create new Enemie", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
    public float Speed => _speed;
}
