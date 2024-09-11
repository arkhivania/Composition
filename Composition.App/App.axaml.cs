using Autofac;
using Autofac.Core.Lifetime;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

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
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterType<MainWindow>();
            builder.RegisterModule(new Composition.Tools.HelloTool.Module());
            builder.RegisterModule(new Composition.Tools.MessageBox.Module());

            var container = builder.Build();
            var lifetimeScope = container.BeginLifetimeScope();

            var mainWindow = lifetimeScope.Resolve<MainWindow>();

            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
