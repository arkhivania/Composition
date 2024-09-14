using System;
using System.Windows.Input;

namespace Composition.Tools.MainMenu.Base;

public struct MainMenuInstallation
{
    public int Order { get; set; }
    public ICommand? Command { get; set; }
    public string DisplayName { get; set; }
    public string Location { get; set; }
}
