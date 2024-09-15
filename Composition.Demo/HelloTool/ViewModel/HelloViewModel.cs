using System;
using System.Globalization;
using Composition.ClientBase.MVVM;
using Composition.Tools.SettingsStore.Base;
using Composition.Tools.StatusBar.Base;

namespace Composition.Demo.HelloTool.ViewModel;

class HelloViewModel
{
    public RelayCommand IncrementCommand { get; }
    public StateValue<int> Counter { get; } = new StateValue<int>();

    public HelloViewModel(IStatusBar statusBar, ISettingsStorage settingsStorage)
    {
        var storedValue = settingsStorage.GetValue("CounterValue", SettingsLocation.User);
        if (storedValue != null)
            if (int.TryParse(storedValue, CultureInfo.InvariantCulture, out var counterValue))
                Counter.Value = counterValue;

        IncrementCommand = new RelayCommand(() =>
        {
            Counter.Value += 1;
            settingsStorage.StoreValue(
                "CounterValue",
                Counter.Value.ToString(CultureInfo.InvariantCulture),
                SettingsLocation.User
            );
        });

        statusBar.ShowTemporaryMessage("Counter view model initialized");
    }
}
