using System;

namespace Composition.Tools.MessageBox.Base;

public interface IMessageBox
{
    void ShowMessage(string message);
    bool? ShowQuestion(string question);
}
