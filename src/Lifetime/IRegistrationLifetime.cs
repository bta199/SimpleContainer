using System;

namespace SimpleContainer.Lifetime;

public interface IRegistrationLifetime
{
    public Func<TImplementation> GetProvider<TImplementation>(IContainerInstanceStore instanceStore);
}
