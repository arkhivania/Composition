using Autofac;
using Avalonia.Controls;
using Composition.ClientBase;
using Composition.Tools.DockLayout.Base;

namespace Composition.Tools.HelloTool;

class Installer(ViewModel.HelloViewModel helloViewModel) : IDockInstaller
{
    private readonly ViewModel.HelloViewModel helloViewModel = helloViewModel;

    public int Order => 0;

    public IEnumerable<DockInstallation> DockInstall()
    {
        yield return new DockInstallation
        {
            Control = new Views.HelloView(helloViewModel),
            Order = 0,
        };
    }
}
