using UnityEngine;

public class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform Parent;
    [SerializeField] protected int PoolMaxSize;
    [SerializeField] protected ObjectsRemover Remover;

    protected Pool<T> Pool;
    protected Coroutine SpawningCoroutine;

    protected virtual void Awake()
    {
        Pool = new Pool<T>(PoolMaxSize, transform);
    }

    protected virtual void OnDisable()
    {
        if (SpawningCoroutine != null)
            StopCoroutine(SpawningCoroutine);
    }

    protected T GetObject(T prefab)
    {
        var obj = Pool.Get(prefab);

        return obj;
    }

    protected virtual void Spawn(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void Release(T obj)
    {
        Pool.Release(obj);
    }
}
