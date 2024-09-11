using System;
using Autofac;

namespace Composition.Bootstraps.Demo1;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new Composition.Tools.HelloTool.Module());
        builder.RegisterModule(new Composition.Tools.PanelView.Module());
    }
}
