using System;
using Avalonia.Controls;

namespace Composition.ClientBase;

public interface IToolsPanelArrange
{
    int Order { get; }
    IEnumerable<IDisposable> ArrangeToolsPanel(StackPanel stackPanel);
}
