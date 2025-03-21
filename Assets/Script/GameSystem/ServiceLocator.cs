using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void Register(object service)
    {
        Type serviceType = service.GetType();
        if (_services.ContainsKey(serviceType))
            throw new InvalidOperationException($"The {serviceType} service is already registered.");

        _services[serviceType] = service;
    }

    public static object Get(Type serviceType)
    {
        if (_services.TryGetValue(serviceType, out var instance))
            return instance;

        throw new Exception($"Service {serviceType} not found.");
    }

    public static T Get<T>()
    {
        Type serviceType = typeof(T);
        if (_services.TryGetValue(serviceType, out var instance))
            return (T)instance;

        throw new Exception($"Service {serviceType} not found.");
    }
}
