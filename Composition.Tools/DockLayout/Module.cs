using System;
using Autofac;
using Composition.ClientBase;

namespace Composition.Tools.DockLayout;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DockController>().As<IInitialize>();
    }
}
