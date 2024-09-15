using System;
using Avalonia.Threading;

namespace Composition.Tools.StatusBar.Base;

public static class Extensions
{
    public static IDisposable ShowTemporaryMessage(this IStatusBar statusBar, string message)
    {
        return statusBar.ShowTemporaryMessage(message, TimeSpan.FromSeconds(5));
    }

    public static IDisposable ShowTemporaryMessage(
        this IStatusBar statusBar,
        string message,
        TimeSpan period
    )
    {
        var section = statusBar.CreateSection();
        section.StatusText.Value = message;

        Task.Delay(period).ContinueWith(_ => section.Dispose(), TaskScheduler.Current);
        return section;
    }
}
