using System;

namespace Composition.ClientBase;

public interface IInitialize
{
    int Order { get; }
    Task Initialize();
}
