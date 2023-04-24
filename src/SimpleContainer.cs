using System;
using System.Collections.Generic;
using SimpleContainer.Lifetime;

namespace SimpleContainer;

public class SimpleContainer : IContainer
{
    private IDictionary<Type, Registration> _registrations = new Dictionary<Type, Registration>();
    private IContainerInstanceStore _instanceStore = new ContainerInstanceStore();

    public TInterface Get<TInterface>()
    {
        return (TInterface)GetInternal(typeof(TInterface));
    }

    public object Get(Type type)
    {
        return GetInternal(type);
    }

    public void Register<TInterface, TImplementation, TLifetime>()
        where TLifetime : IRegistrationLifetime, new()
    {
        var lifetime = new TLifetime();
        var provider = lifetime.GetProvider<TImplementation>(_instanceStore);

        if (provider == null)
        {
            throw new InvalidOperationException("Lifetime did not produce a provider.");
        }

        _registrations.Add(typeof(TInterface), new Registration(typeof(TImplementation), () =>
        {
            var result = provider();
            if (result == null)
            {
                throw new InvalidOperationException("Provider did not retrieve an instance.");
            }

            return provider;
        }));
    }

    private object GetInternal(Type type)
    {
        if (!_registrations.TryGetValue(type, out var registration))
        {
            throw new InvalidOperationException($"{type} is not registered.");
        }

        return registration.Factory();
    }
}
