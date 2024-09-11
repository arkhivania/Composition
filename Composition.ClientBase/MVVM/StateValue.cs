using System;
using System.ComponentModel;

namespace Composition.ClientBase.MVVM;

public class StateValue<T> : INotifyPropertyChanged
{
    T? value;
    public T? Value
    {
        get { return this.value; }
        set
        {
            this.value = value;
            ValueChanged?.Invoke(this, EventArgs.Empty);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        }
    }

    public event EventHandler? ValueChanged;
    public event PropertyChangedEventHandler? PropertyChanged;
}
