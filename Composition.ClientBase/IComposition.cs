using System;

namespace Composition.ClientBase;

public interface IComposition
{
    IDisposable SetupView(Avalonia.Controls.Control mainViewControl);
}
