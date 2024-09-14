using System;
using Avalonia.Controls;

namespace Composition.Tools.DockLayout.Base;

public struct DockInstallation
{
    public int Order { get; set; }
    public Control Control { get; set; }
    public Dock? Dock { get; set; }
}
