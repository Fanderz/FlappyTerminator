using UnityEngine;

public class BirdAnimator : MonoBehaviour
{
    private Animator _animator;
    private Bird _bird;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _bird = GetComponent<Bird>();
    }

    private void OnEnable()
    {
        _bird.AnimatorParameterChanged += ChangeParameter;
    }

    private void OnDisable()
    {
        _bird.AnimatorParameterChanged -= ChangeParameter;
    }

    private void ChangeParameter(bool isFlying)
    {
        _animator.SetBool(BirdAnimatorData.Params.IsFlying, isFlying);
    }
}
