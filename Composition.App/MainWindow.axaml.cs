using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Composition.ClientBase;

namespace Composition.App;

public partial class MainWindow : Window, IComposition
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        var builder = new Autofac.ContainerBuilder();
        builder.RegisterInstance(this).As<IComposition>();
        builder.RegisterModule<Composition.Bootstraps.Demo1.Module>();

        var container = builder.Build();

        foreach (
            var i in container.Resolve<IEnumerable<IInitialize>>().OrderBy(w => w.InitializeOrder)
        )
            i.Initialize();

        this.Unloaded += delegate
        {
            container.Dispose();
        };
    }

    IDisposable? installedView;

    public IDisposable SetupView(Control mainViewControl)
    {
        installedView?.Dispose();
        this.Content = mainViewControl;
        return installedView = new DisposeAction(() => this.Content = null);
    }
}
