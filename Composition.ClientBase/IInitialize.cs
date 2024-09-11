using System;

namespace Composition.ClientBase;

public interface IInitialize
{
    int InitializeOrder { get; }
    void Initialize();
}
