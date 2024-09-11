using System;

namespace Composition.Tools.MessageBox.Base;

public interface IMessageBox
{
    Task ShowMessage(string message);
    Task<bool?> ShowQuestion(string question);
}
