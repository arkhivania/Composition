using Autofac;

namespace Composition.Tools.StatusBar;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<ViewModel.StatusBarViewModel>()
            .As<Base.IStatusBar, ViewModel.StatusBarViewModel>()
            .SingleInstance();
        builder.RegisterType<Installer>().As<DockLayout.Base.IDockInstaller>();
    }
}
