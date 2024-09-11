using System;
using Composition.ClientBase.MVVM;
using Composition.Tools.MessageBox.Base;

namespace Composition.Tools.HelloTool.ViewModel;

class HelloViewModel
{
    public RelayCommand SayHelloCommand { get; }

    public HelloViewModel(IMessageBox messageBox)
    {
        SayHelloCommand = new RelayCommand(() => messageBox.ShowMessage("Hello"));
    }

}
