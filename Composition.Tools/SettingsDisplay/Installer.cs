using System;
using Composition.Tools.MainMenu.Base;

namespace Composition.Tools.SettingsDisplay;

class Installer(ShowSettingsPageController controller) : IMainMenuInstaller
{
    private readonly ShowSettingsPageController controller = controller;

    public IEnumerable<MainMenuInstallation> MainMenuInstall()
    {
        yield return new MainMenuInstallation
        {
            Command = controller.ShowDialogCommand,
            DisplayName = "Preferences",
            Location = "File",
            Order = 0,
        };
    }
}
