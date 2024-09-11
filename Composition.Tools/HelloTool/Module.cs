using Autofac;
using Composition.Tools.PanelView.Base;

namespace Composition.Tools.HelloTool;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Views.HelloView>();
        builder.RegisterType<Arranger>().As<IToolsPanelArrange>();
    }
}
