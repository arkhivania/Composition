using System;
using Composition.Tools.SettingsDisplay.Base;

namespace Composition.Demo.HelloTool;

class SettingsProvider : ISettingsUIProvider
{
    public IEnumerable<SettingsUIItem> GetSettingsItems()
    {
        yield return new SettingsUIItem
        {
            Control = new Avalonia.Controls.Button() { Content = "Hello settings!!!" },
            GroupName = "",
            TabName = "Main",
            Order = 0,
        };
    }
}
