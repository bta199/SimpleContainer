using System;

namespace SimpleContainer;

public class Registration
{
    public Registration(Type implementationType, Func<object> factory)
    {
        Type = implementationType;
        Factory = factory;
    }

    public Type Type { get; }

    public Func<object> Factory { get; }
}