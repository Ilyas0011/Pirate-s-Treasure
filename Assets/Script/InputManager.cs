using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputManager: Singleton<InputManager>
{
    private InputConfiguration _inputConfiguration;
    public Action<Vector3> Move;
    public Action Jump;

    public void Initialization()
    {
        InitializeSingleton(this);

        _inputConfiguration = new InputConfiguration();
        _inputConfiguration.Enable();

        _inputConfiguration.Gameplay.Jump.performed += _ => Jump?.Invoke();

        _inputConfiguration.Gameplay.Move.performed += _ => Move?.Invoke(_inputConfiguration.Gameplay.Move.ReadValue<Vector3>());
        _inputConfiguration.Gameplay.Move.canceled += _ => Move?.Invoke(_inputConfiguration.Gameplay.Move.ReadValue<Vector3>());
    }
}
