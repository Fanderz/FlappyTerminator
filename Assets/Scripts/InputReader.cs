using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isFlying;
    private KeyCode _flyCode = KeyCode.W;

    private void Update()
    {
        if (Input.GetKeyDown(_flyCode))
            _isFlying = true;
    }

    public bool GetIsFlying() =>
        GetBoolAsTrigger(ref _isFlying);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}
