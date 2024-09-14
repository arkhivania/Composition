using System;

namespace Composition.Tools.DockLayout.Base;

public interface IDockInstaller
{
    IEnumerable<DockInstallation> DockInstall();
}
