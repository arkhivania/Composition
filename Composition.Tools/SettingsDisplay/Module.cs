using System;
using Autofac;

namespace Composition.Tools.SettingsDisplay;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ShowSettingsPageController>();
        builder.RegisterType<Installer>().As<MainMenu.Base.IMainMenuInstaller>();
    }

}
