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
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotation = GetComponent<BirdRotation>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.velocity = new Vector2(_speed, _flyForce);
            _animator.SetBool("Fly", true);
            _rotation.Rotate();
        }
        else
        {
            _animator.SetBool("Fly", false);
        }
    }
}
