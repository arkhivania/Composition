using System;
using Autofac;

namespace Composition.Tools.LogsDisplay;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<Controller>()
            .AsSelf()
            .As<Logs.Base.ILogInterceptor>()
            .SingleInstance();
        builder.RegisterType<Installer>().As<MainMenu.Base.IMainMenuInstaller>();
    }
}
