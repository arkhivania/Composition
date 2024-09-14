using System;
using System.Linq;
using Avalonia.Controls;
using Composition.Tools.DockLayout.Base;
using Composition.Tools.MainMenu.Base;

namespace Composition.Tools.MainMenu;

class Installer(Base.IMainMenuInstaller[] menuInstallers) : IDockInstaller
{
    private readonly IMainMenuInstaller[] menuInstallers = menuInstallers;

    public IEnumerable<DockInstallation> DockInstall()
    {
        var mainMenu = new Menu();
        var installations = menuInstallers
            .SelectMany(w => w.MainMenuInstall())
            .OrderBy(w => w.Order);

        var locationItems = new Dictionary<string, ItemCollection>();
        locationItems[""] = mainMenu.Items;

        ItemCollection getParent(string location)
        {
            if (locationItems.TryGetValue(location, out var collection))
                return collection;

            var splitted = location.Split("/", StringSplitOptions.RemoveEmptyEntries);
            var parent = getParent(string.Join("/", splitted.Take(splitted.Length - 1)));

            var menuItem = new MenuItem() { Header = splitted.Last() };
            parent.Add(menuItem);
            locationItems[location] = menuItem.Items;
            return menuItem.Items;
        }

        foreach (var mi in installations)
        {
            var parent = getParent(mi.Location);
            var menuItem = new MenuItem() { Command = mi.Command, Header = mi.DisplayName };
            parent.Add(menuItem);
        }

        yield return new DockInstallation
        {
            Control = mainMenu,
            Dock = Dock.Top,
            Order = -100,
        };
    }
}
