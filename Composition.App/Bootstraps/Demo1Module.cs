using System;
using Autofac;

namespace Composition.App.Bootstraps;

public class Demo1Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new Composition.Tools.HelloTool.Module());
        builder.RegisterModule(new Composition.Tools.PanelView.Module());
    }
}
