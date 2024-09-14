using System;
using Composition.ClientBase.MVVM;

namespace Composition.Tools.StatusBar.Base;

public interface IStatusBarSection : IDisposable
{
    StateValue<string> StatusText { get; }
}
