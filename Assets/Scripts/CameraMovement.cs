using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _offset;

    private void Update()
    {
        var birdPosition = transform.position;
        birdPosition.x = _bird.transform.position.x + _offset;

        transform.position = birdPosition;
    }
}
