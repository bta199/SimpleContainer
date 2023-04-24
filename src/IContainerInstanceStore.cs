namespace SimpleContainer;

public interface IContainerInstanceStore
{
    public bool Exists<TInstance>();

    public TInstance Get<TInstance>();

    public void Set<TInstance>(TInstance instance);
}
