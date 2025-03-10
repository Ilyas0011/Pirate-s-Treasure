using System;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected void InitializeMonoSingleton(T instance)
    {
        if (Instance == null)
            Instance = instance;
        else
            throw new Exception($"{instance} singleton already initialized");
    }
}
