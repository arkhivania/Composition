using System;

namespace Composition.Tools.SettingsStore.Base;

public interface ISettingsStorage
{
    void StoreValue(string key, string value, SettingsLocation location);
    string? GetValue(string key, SettingsLocation location);
}
