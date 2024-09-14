using System;
using Autofac;
using Composition.ClientBase;
using Composition.Tools.DockLayout.Base;

namespace Composition.Tools.DockLayout;

public class DockController : IInitialize
{
    private readonly IComposition composition;
    private readonly IDockInstaller[] dockInstallers;

    public int Order => 0;

    public DockController(IComposition composition, IDockInstaller[] dockInstallers)
    {
        this.composition = composition;
        this.dockInstallers = dockInstallers;
    }

    Task IInitialize.Initialize()
    {
        var dockPanel = new Avalonia.Controls.DockPanel();
        var installations = dockInstallers.SelectMany(w => w.DockInstall());

        foreach (var installation in installations.OrderBy(w => w.Order))
        {
            if (installation.Dock != null)
                Avalonia.Controls.DockPanel.SetDock(installation.Control, installation.Dock.Value);

            dockPanel.Children.Add(installation.Control);
        }

        composition.SetupView(dockPanel);
        return Task.CompletedTask;
    }
}
