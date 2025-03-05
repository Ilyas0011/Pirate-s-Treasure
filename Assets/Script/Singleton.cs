using UnityEngine;
using System;

public abstract class Singleton<T>
{
    public static T Instance;
    protected void InitializeSingleton(T instance)
    {
        if (Instance == null)
            Instance = instance;
        else
           throw new Exception($"{instance} singleton already initialized");
    }
}