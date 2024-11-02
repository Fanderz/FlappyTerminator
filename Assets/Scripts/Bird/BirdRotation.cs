using UnityEngine;

public class BirdRotation : MonoBehaviour
{
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _rotationSpeed;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Rotate()
    {
        transform.rotation = _maxRotation;
    }
}
