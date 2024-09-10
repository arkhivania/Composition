using System;
using Autofac;
using Avalonia.Controls;
using Composition.ClientBase;
using Composition.MVVM;

namespace Composition.Tools.HelloTool;

public class Module : Autofac.Module, IToolsPanelArrange
{
    public int Order => 0;

    public IEnumerable<IDisposable> ArrangeToolsPanel(StackPanel stackPanel)
    {
        var view = new Views.HelloView();
        stackPanel.Children.Add(view);
        yield return new DisposeAction(() => stackPanel.Children.Remove(view));
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Views.HelloView>();
        builder.RegisterInstance<IToolsPanelArrange>(this);
    }
}
