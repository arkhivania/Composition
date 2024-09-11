using System;
using Avalonia.Controls;

namespace Composition.Tools.PanelView.Base;

public interface IToolsPanelArrange
{
    int Order { get; }
    IEnumerable<IDisposable> ArrangeToolsPanel(StackPanel stackPanel);
}
