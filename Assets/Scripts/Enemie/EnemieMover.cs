using UnityEngine;

public class EnemieMover : MonoBehaviour
{
    [SerializeField] private Enemie _enemie;

    public Enemie Enemie => _enemie;

    private void Update()
    {
        transform.Translate(_enemie.Speed * Time.deltaTime * Vector2.left);
    }
}
