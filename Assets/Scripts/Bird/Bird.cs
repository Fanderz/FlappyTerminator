using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool _isFlying;
    private InputReader _inputReader;

    public event Action Dead;
    public event Action Flying;
    public event Action<bool> AnimatorParameterChanged;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void FixedUpdate()
    {
        if (_isFlying = _inputReader.GetIsFlying())
        {
            Flying?.Invoke();
            AnimatorParameterChanged?.Invoke(_isFlying);
            _isFlying = false;
        }
        else
        {
            AnimatorParameterChanged?.Invoke(_isFlying);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead?.Invoke();
    }
}