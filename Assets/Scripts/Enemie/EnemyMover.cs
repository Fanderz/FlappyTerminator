using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyData _enemie;

    public EnemyData Enemie => _enemie;

    private void Update()
    {
        transform.Translate(_enemie.Speed * Time.deltaTime * Vector2.left);
    }
}
