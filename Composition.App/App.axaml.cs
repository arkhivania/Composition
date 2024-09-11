using System.Collections.Generic;
using System.Linq;
using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Composition.ClientBase;

namespace Composition.App;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow();
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterInstance(mainWindow).As<IComposition>();
            builder.RegisterModule<Composition.Bootstraps.Demo1.Module>();

            var container = builder.Build();

            foreach (
                var i in container
                    .Resolve<IEnumerable<IInitialize>>()
                    .OrderBy(w => w.InitializeOrder)
            )
                i.Initialize();

            desktop.MainWindow = mainWindow;

            mainWindow.Unloaded += delegate
            {
                container.Dispose();
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
