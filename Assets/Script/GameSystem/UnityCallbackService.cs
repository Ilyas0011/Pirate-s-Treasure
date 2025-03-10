using System;
using UnityEngine;

public class UnityCallbackService : MonoBehaviour
{
    public Action PhysicsUpdated;
    public Action FrameUpdated;

    public static UnityCallbackService Instance;

    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
        else
            throw new Exception($"UnityCallbackService is already initialized");
    }

    private void FixedUpdate() => PhysicsUpdated?.Invoke();
    private void Update() => FrameUpdated?.Invoke();
}
