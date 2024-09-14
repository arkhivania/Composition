using System;
using Autofac;

namespace Composition.App.Bootstraps;

public class Demo1Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new Composition.Tools.DockLayout.Module());
        builder.RegisterModule(new Composition.Tools.MainMenu.Module());
        builder.RegisterModule(new Composition.Tools.HelloTool.Module());
    }
}
