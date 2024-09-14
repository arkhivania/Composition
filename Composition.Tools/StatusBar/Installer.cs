using System;
using Composition.Tools.DockLayout.Base;
using Composition.Tools.StatusBar.ViewModel;

namespace Composition.Tools.StatusBar;

class Installer(ViewModel.StatusBarViewModel viewModel) : DockLayout.Base.IDockInstaller
{
    private readonly StatusBarViewModel viewModel = viewModel;

    public IEnumerable<DockInstallation> DockInstall()
    {
        yield return new DockInstallation
        {
            Control = new Views.StatusBarControl(viewModel),
            Dock = Avalonia.Controls.Dock.Bottom,
            Order = 0,
        };
    }
}
