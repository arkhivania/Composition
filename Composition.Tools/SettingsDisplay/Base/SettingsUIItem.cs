using System;

namespace Composition.Tools.SettingsDisplay.Base;

public struct SettingsUIItem
{
    public Avalonia.Controls.Control Control { get; set; }
    public string TabName { get; set; }
    public string GroupName { get; set; }
    public int Order { get; set; }
}