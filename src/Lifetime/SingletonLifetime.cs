using System;

namespace SimpleContainer.Lifetime;

public class SingletonLifetime : IRegistrationLifetime
{
    public Func<TImplementation> GetProvider<TImplementation>(IContainerInstanceStore instanceStore)
    {
        return () =>
        {
            if (!instanceStore.Exists<TImplementation>())
            {
                var implementation = Activator.CreateInstance<TImplementation>();
                instanceStore.Set<TImplementation>(implementation);
                return implementation;
            }

            return instanceStore.Get<TImplementation>();
        };
    }
}
