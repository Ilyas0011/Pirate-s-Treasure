using System;
using UnityEngine;

public class InputManager: Singleton<InputManager>
{
    private bool _isMovement;

    public Action<float, float> Move;
    public Action<float, float> Look;
    public Action Jump;

    public InputManager()
    {
        UnityCallbackService.Instance.FrameUpdated += InputUpdate;

        InitializeSingleton(this);
        SetMovementEnabled(true);
    }

    public void SetMovementEnabled(bool isEnabled) => _isMovement = isEnabled;

    public void InputUpdate()
    {
        if (_isMovement)
        {
            Move?.Invoke(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Look?.Invoke(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if (Input.GetKeyDown(KeyCode.Space))
                Jump?.Invoke();
        }
    }
}
