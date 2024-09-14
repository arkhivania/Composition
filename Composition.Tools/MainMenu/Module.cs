using Autofac;
using Composition.Tools.DockLayout.Base;

namespace Composition.Tools.MainMenu;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Installer>().As<IDockInstaller>();
    }
}
