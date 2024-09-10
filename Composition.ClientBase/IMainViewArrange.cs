using System;
using Avalonia.Controls;

namespace Composition.ClientBase;

public interface IMainViewArrange
{
    int Order { get; }
    IEnumerable<IDisposable> ArrangeView(Grid grid);
}
