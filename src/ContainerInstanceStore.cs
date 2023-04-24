using System;
using System.Collections.Generic;

namespace SimpleContainer;

public class ContainerInstanceStore : IContainerInstanceStore
{
    private IDictionary<Type, object> _instances = new Dictionary<Type, object>();

    public bool Exists<TInstance>()
    {
        return _instances.ContainsKey(typeof(TInstance));
    }

    public TInstance Get<TInstance>()
    {
        if (!_instances.TryGetValue(typeof(TInstance), out var instance))
        {
            throw new InvalidOperationException($"{typeof(TInstance)} is not registered");
        }

        return (TInstance)instance;
    }

    public void Set<TInstance>(TInstance instance)
    {
        if (instance == null)
        {
            throw new InvalidOperationException("Cannot set a null instance into the container.");
        }

        _instances.Add(typeof(TInstance), instance);
    }
}
