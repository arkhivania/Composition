using System;
using Composition.Tools.MainMenu.Base;

namespace Composition.Tools.LogsDisplay;

class Installer : IMainMenuInstaller
{
    private readonly Controller controller;

    public Installer(Controller controller)
    {
        this.controller = controller;
    }

    public IEnumerable<MainMenuInstallation> MainMenuInstall()
    {
        yield return new MainMenuInstallation
        {
            Command = controller.ShowLogsCommand, 
            DisplayName = "Logs", 
            Location = "Help", 
            Order = 50
        };
    }
}
