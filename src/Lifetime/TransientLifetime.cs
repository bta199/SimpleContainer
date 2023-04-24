using System;

namespace SimpleContainer.Lifetime;

public class TransientLifetime : IRegistrationLifetime
{
    public Func<TImplementation> GetProvider<TImplementation>(IContainerInstanceStore instanceStore)
    {
        return () => Activator.CreateInstance<TImplementation>();
    }
}
