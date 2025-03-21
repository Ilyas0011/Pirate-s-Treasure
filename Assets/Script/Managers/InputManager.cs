using System;
using System.Threading.Tasks;
using UnityEngine;

public class InputManager: IInitializable
{
    private UnityCallbackService _unityCallbackService;

    private bool _isMovement;

    public Action<float, float> Move;
    public Action<float, float> Look;
    public Action Jump;
    public bool IsReady { get; set; }
    public bool DontAutoInit { get; }

    public Task Init()
    {
        _unityCallbackService = ServiceLocator.Get<UnityCallbackService>();

        _unityCallbackService.FrameUpdated += InputUpdate;

        SetMovementEnabled(true);

        return Task.CompletedTask;
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
