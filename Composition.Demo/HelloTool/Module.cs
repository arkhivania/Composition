using Autofac;
using Composition.Demo.HelloTool.ViewModel;
using Composition.Demo.HelloTool.Views;
using Composition.Tools.DockLayout.Base;
using Composition.Tools.MainMenu.Base;

namespace Composition.Demo.HelloTool;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HelloView>();
        builder.RegisterType<HelloViewModel>().SingleInstance();
        builder.RegisterType<Installer>().As<IDockInstaller, IMainMenuInstaller>();
        builder
            .RegisterType<SettingsProvider>()
            .As<Composition.Tools.SettingsDisplay.Base.ISettingsUIProvider>();
    }
}
