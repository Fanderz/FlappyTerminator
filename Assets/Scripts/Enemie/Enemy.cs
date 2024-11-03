using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private const int BirdBulletLayer = 8;

    public UnityEvent<EnemyView> Collised;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == BirdBulletLayer)
        {
            Collised?.Invoke(this.GetComponent<EnemyView>());
            Collised.RemoveAllListeners();
        }
    }
}
