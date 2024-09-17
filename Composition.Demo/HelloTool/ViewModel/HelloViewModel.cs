using System;
using System.Globalization;
using System.Security.Cryptography;
using Composition.ClientBase.MVVM;
using Composition.Tools.Logs.Base;
using Composition.Tools.SettingsStore.Base;
using Composition.Tools.StatusBar.Base;

namespace Composition.Demo.HelloTool.ViewModel;

class HelloViewModel
{
    private readonly IStatusBar statusBar;
    private readonly ISettingsStorage settingsStorage;
    private readonly ILogger logger;

    public RelayCommand IncrementCommand { get; }
    public StateValue<int> Counter { get; } = new StateValue<int>();

    public HelloViewModel(IStatusBar statusBar, ISettingsStorage settingsStorage, ILogger logger)
    {
        this.statusBar = statusBar;
        this.settingsStorage = settingsStorage;
        this.logger = logger;

        var storedValue = settingsStorage.GetValue("CounterValue", SettingsLocation.User);
        if (storedValue != null)
            if (int.TryParse(storedValue, CultureInfo.InvariantCulture, out var counterValue))
                Counter.Value = counterValue;

        IncrementCommand = new RelayCommand(() =>
        {
            Counter.Value += 1;
            logger.Info($"Increment executed: {Counter.Value}");
            settingsStorage.StoreValue(
                "CounterValue",
                Counter.Value.ToString(CultureInfo.InvariantCulture),
                SettingsLocation.User
            );
        });

        statusBar.ShowTemporaryMessage("Counter view model initialized");
        logger.Info("Hello view model initialized");
    }
}
