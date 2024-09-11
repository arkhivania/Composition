using System;
using Autofac;
using Composition.ClientBase;

namespace Composition.Tools.PanelView;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Views.PanelView>();
        builder.RegisterType<Initializer>().As<IInitialize>();
    }
}
