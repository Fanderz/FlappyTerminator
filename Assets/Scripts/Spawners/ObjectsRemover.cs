using System;
using UnityEngine;

public class ObjectsRemover : MonoBehaviour
{
    public event Action<EnemyView> ReleasingEnemie;
    public event Action<BulletView> ReleasingBullet;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
            ReleasingEnemie?.Invoke(collider.gameObject.GetComponent<EnemyView>());
        else if (collider.gameObject.layer == 7 || collider.gameObject.layer == 8)
            ReleasingBullet?.Invoke(collider.gameObject.GetComponent<BulletView>());
    }
}