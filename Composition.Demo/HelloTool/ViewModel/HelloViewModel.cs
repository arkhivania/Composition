using System;
using Composition.ClientBase.MVVM;
using Composition.Tools.StatusBar.Base;

namespace Composition.Demo.HelloTool.ViewModel;

class HelloViewModel
{
    public RelayCommand IncrementCommand { get; }
    public StateValue<int> Counter { get; } = new StateValue<int>();

    public HelloViewModel(IStatusBar statusBar)
    {
        IncrementCommand = new RelayCommand(() =>
        {
            Counter.Value += 1;
        });

        statusBar.ShowTemporaryMessage("Counter view model initialized");
    }
}
