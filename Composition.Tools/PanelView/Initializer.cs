using Autofac;
using Composition.ClientBase;

namespace Composition.Tools.PanelView;

class Initializer : IInitialize
{
    private readonly IComposition composition;
    private readonly IComponentContext componentContext;

    public int InitializeOrder => 0;

    public Initializer(IComposition composition, IComponentContext componentContext)
    {
        this.composition = composition;
        this.componentContext = componentContext;
    }

    public void Initialize()
    {
        composition.SetupView(componentContext.Resolve<Views.PanelView>());
    }
}
