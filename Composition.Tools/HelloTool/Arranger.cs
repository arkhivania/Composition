using Autofac;
using Avalonia.Controls;
using Composition.ClientBase;
using Composition.Tools.PanelView.Base;

namespace Composition.Tools.HelloTool;

class Arranger(IComponentContext container) : IToolsPanelArrange
{
    private readonly IComponentContext container = container;

    public int Order => 0;

    public IEnumerable<IDisposable> ArrangeToolsPanel(StackPanel stackPanel)
    {
        var view = container.Resolve<Views.HelloView>();
        stackPanel.Children.Add(view);
        yield return new DisposeAction(() => stackPanel.Children.Remove(view));
    }
}
