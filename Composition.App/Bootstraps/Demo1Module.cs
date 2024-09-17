using System;
using Autofac;

namespace Composition.App.Bootstraps;

public class Demo1Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .Register(_ => new Composition.Tools.SettingsStore.Base.SettingsStoreSettings
            {
                ApplicationName = "CompositionApp",
            })
            .AsSelf();

        builder.RegisterModule(new Composition.Tools.DockLayout.Module());
        builder.RegisterModule(new Composition.Tools.MainMenu.Module());
        builder.RegisterModule(new Composition.Tools.StatusBar.Module());
        builder.RegisterModule(new Composition.Tools.SettingsDisplay.Module());
        builder.RegisterModule(new Composition.Tools.SettingsStore.Module());
        builder.RegisterModule(new Composition.Tools.Logs.Module());
        builder.RegisterModule(new Composition.Tools.LogsDisplay.Module());

        builder.RegisterModule(new Composition.Demo.HelloTool.Module());
    }
}
