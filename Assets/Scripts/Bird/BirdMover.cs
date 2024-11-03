using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BirdRotation))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _flyForce;

    private Rigidbody2D _rigidbody;
    private BirdRotation _rotation;
    private Bird _bird;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotation = GetComponent<BirdRotation>();
        _bird = GetComponent<Bird>();
    }

    private void OnEnable()
    {
        _bird.Flying += Fly;
    }

    private void OnDisable()
    {
        _bird.Flying -= Fly;
    }

    private void Fly()
    {
        _rigidbody.velocity = new Vector2(_speed, _flyForce);
        _rotation.Rotate();
    }
}
