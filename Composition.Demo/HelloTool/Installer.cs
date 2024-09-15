using Composition.Demo.HelloTool.ViewModel;
using Composition.Tools.DockLayout.Base;
using Composition.Tools.MainMenu.Base;

namespace Composition.Demo.HelloTool;

class Installer(HelloViewModel helloViewModel) : IDockInstaller, IMainMenuInstaller
{
    private readonly HelloViewModel helloViewModel = helloViewModel;

    public int Order => 0;

    public IEnumerable<DockInstallation> DockInstall()
    {
        yield return new DockInstallation
        {
            Control = new Views.HelloView(helloViewModel),
            Order = 1000,
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
