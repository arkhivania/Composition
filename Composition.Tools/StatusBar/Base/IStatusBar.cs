using System;

namespace Composition.Tools.StatusBar.Base;

public interface IStatusBar
{
    IStatusBarSection CreateSection();
}
