using Autofac;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace Composition.ClientBase.Common;

public class CompositionWindow : Window, IComposition
{
    private readonly Action<ContainerBuilder> builderInitializer;

    IDisposable? installedView;
    IContainer? container;

    public CompositionWindow(Action<ContainerBuilder> builderInitializer)
    {
        this.builderInitializer = builderInitializer;
    }

    protected override async void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        var builder = new ContainerBuilder();
        builder.RegisterInstance(this).As<IComposition>();
        this.builderInitializer(builder);

        this.container = builder.Build();
        foreach (var i in this.container.Resolve<IEnumerable<IInitialize>>().OrderBy(w => w.Order))
            await i.Initialize();
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        installedView?.Dispose();
        container?.Dispose();
        container = null;
    }

    public IDisposable SetupView(Control mainViewControl)
    {
        if (this.installedView != null)
            throw new InvalidOperationException("View already installed");

        this.Content = mainViewControl;
        return this.installedView = new DisposeAction(() =>
        {
            this.Content = null;
            this.installedView = null;
        });
    }
}
