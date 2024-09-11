using Autofac;
using Avalonia.Controls;
using Composition.ClientBase;
using Composition.Tools.PanelView.Base;

namespace Composition.Tools.HelloTool;

class Arranger(IComponentContext container) : IToolsPanelArrange, IMainViewArrange
{
    private readonly IComponentContext container = container;

    public int Order => 0;

    public IEnumerable<IDisposable> ArrangeToolsPanel(StackPanel stackPanel)
    {
        var view = container.Resolve<Views.HelloView>();
        stackPanel.Children.Add(view);
        yield return new DisposeAction(() => stackPanel.Children.Remove(view));
    }

    public IEnumerable<IDisposable> ArrangeView(Grid grid)
    {
        var view = container.Resolve<Views.HelloView>();
        grid.Children.Add(view);
        yield return new DisposeAction(() => grid.Children.Remove(view));
    }
}
