using Autofac;
using Avalonia.Controls;
using Composition.ClientBase;
using Composition.Tools.DockLayout.Base;
using Composition.Tools.MainMenu.Base;

namespace Composition.Tools.HelloTool;

class Installer(ViewModel.HelloViewModel helloViewModel)
    : IDockInstaller,
        MainMenu.Base.IMainMenuInstaller
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

    public IEnumerable<MainMenuInstallation> MainMenuInstall()
    {
        yield return new MainMenuInstallation
        {
            Command = helloViewModel.IncrementCommand,
            DisplayName = "Increment",
            Location = "Operation",
        };
    }
}
