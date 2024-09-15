using System;
using Autofac;

namespace Composition.Tools.SettingsStore;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .Register(_ => GetDefaultSettings())
            .AsSelf()
            .IfNotRegistered(typeof(Base.SettingsStoreSettings));
        builder.RegisterType<Processing.Storage>().As<Base.ISettingsStorage>();
    }

    private Base.SettingsStoreSettings GetDefaultSettings()
    {
        var res = new Base.SettingsStoreSettings
        {
            ApplicationName = System.AppDomain.CurrentDomain.FriendlyName,
        };
        return res;
    }
}
