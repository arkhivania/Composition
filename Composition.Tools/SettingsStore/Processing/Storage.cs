using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Composition.Tools.SettingsStore.Base;

namespace Composition.Tools.SettingsStore.Processing;

class Storage : Base.ISettingsStorage
{
    private readonly SettingsStoreSettings settings;

    public Storage(Base.SettingsStoreSettings settings)
    {
        this.settings = settings;
    }

    string PatchKey(string key)
    {
        var keySet = new HashSet<char>(key);
        foreach (var c in Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()))
        {
            if (keySet.Contains(c))
                key = key.Replace(c, '_');
        }
        return key;
    }

    string GetLocation(string key, SettingsLocation location)
    {
        var directory = location switch
        {
            SettingsLocation.User => Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData
            ),
            SettingsLocation.Application => Environment.GetFolderPath(
                Environment.SpecialFolder.CommonApplicationData
            ),
            _ => throw new InvalidOperationException($"Unknown location: {location}"),
        };

        var appDirectory = Path.Combine(directory, settings.ApplicationName);
        if (!Directory.Exists(appDirectory))
            Directory.CreateDirectory(appDirectory);

        return Path.Combine(appDirectory, PatchKey(key));
    }

    public string? GetValue(string key, SettingsLocation location)
    {
        var file = GetLocation(key, location);
        if (File.Exists(file))
            return File.ReadAllText(file, Encoding.UTF8);

        return null;
    }

    public void StoreValue(string key, string value, SettingsLocation location)
    {
        File.WriteAllText(GetLocation(key, location), value, Encoding.UTF8);
    }
}
