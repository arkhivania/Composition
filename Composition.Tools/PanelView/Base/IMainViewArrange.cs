using System;
using Avalonia.Controls;

namespace Composition.Tools.PanelView.Base;

public interface IMainViewArrange
{
    int Order { get; }
    IEnumerable<IDisposable> ArrangeView(Grid grid);
}
