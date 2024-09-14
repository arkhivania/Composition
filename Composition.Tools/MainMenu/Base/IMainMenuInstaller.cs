using System;

namespace Composition.Tools.MainMenu.Base;

public interface IMainMenuInstaller
{
    IEnumerable<MainMenuInstallation> MainMenuInstall();
}
