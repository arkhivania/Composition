using System;

namespace Composition.MVVM;

public class DisposeAction : IDisposable
{
    private readonly Action onDispose;

    public DisposeAction(Action onDispose)
    {
        this.onDispose = onDispose;
    }

    public void Dispose()
    {
        onDispose();
    }
}
