using System;

namespace Composition.Tools.SettingsDisplay.Base;

public interface ISettingsUIProvider
{
    IEnumerable<SettingsUIItem> GetSettingsItems();
}
