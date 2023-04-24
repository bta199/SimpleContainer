using System;
using SimpleContainer.Lifetime;

namespace SimpleContainer;

public interface IContainer
{
    public void Register<TInterface, TImplementation, TLifetime>()
        where TLifetime : IRegistrationLifetime, new();

    public TInterface Get<TInterface>();

    public object Get(Type type);
}
