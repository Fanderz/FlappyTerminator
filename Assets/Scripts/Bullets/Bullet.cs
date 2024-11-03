using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityEvent<BulletView> Collised;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Collised?.Invoke(this.GetComponent<BulletView>());
            Collised.RemoveAllListeners();
    }
}
