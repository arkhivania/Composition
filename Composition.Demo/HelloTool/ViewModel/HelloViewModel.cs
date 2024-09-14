using System;
using Composition.ClientBase.MVVM;
using Composition.Tools.StatusBar.Base;

namespace Composition.Demo.HelloTool.ViewModel;

class HelloViewModel : IDisposable
{
    public RelayCommand IncrementCommand { get; }
    public StateValue<int> Counter { get; } = new StateValue<int>();

    readonly IStatusBarSection statusBarSection;

    public HelloViewModel(IStatusBar statusBar)
    {
        statusBarSection = statusBar.CreateSection();

        IncrementCommand = new RelayCommand(() =>
        {
            Counter.Value += 1;
            statusBarSection.StatusText.Value = $"Counter incremented to: {Counter.Value}";
        });

        statusBar.ShowTemporaryMessage("View model initialized");
    }

    public void Dispose()
    {
        statusBarSection.Dispose();
    }
}
