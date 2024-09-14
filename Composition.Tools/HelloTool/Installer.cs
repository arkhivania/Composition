using Autofac;
using Avalonia.Controls;
using Composition.ClientBase;
using Composition.Tools.DockLayout.Base;

namespace Composition.Tools.HelloTool;

class Installer(IComponentContext container) : IDockInstaller
{
    private readonly IComponentContext container = container;

    public int Order => 0;

    public IEnumerable<DockInstallation> DockInstall()
    {
        yield return new DockInstallation
        {
            Control = container.Resolve<Views.HelloView>(),
            Order = 0,
        };
    }
}
