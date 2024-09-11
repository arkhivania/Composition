using System;
using Composition.ClientBase.MVVM;

namespace Composition.Tools.HelloTool.ViewModel;

class HelloViewModel
{
    public RelayCommand IncrementCommand { get; }
    public StateValue<int> Counter { get; } = new StateValue<int>();

    public HelloViewModel()
    {
        IncrementCommand = new RelayCommand(() => Counter.Value += 1);
    }
}
