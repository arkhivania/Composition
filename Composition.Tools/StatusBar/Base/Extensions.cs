using System;

namespace Composition.Tools.StatusBar.Base;

public static class Extensions
{
    public static Task ShowTemporaryMessage(this IStatusBar statusBar, string message)
    {
        return statusBar.ShowTemporaryMessage(message, TimeSpan.FromSeconds(5));
    }

    public static async Task ShowTemporaryMessage(
        this IStatusBar statusBar,
        string message,
        TimeSpan period
    )
    {
        using (var section = statusBar.CreateSection())
        {
            section.StatusText.Value = message;
            await Task.Delay(period);
        }
    }
}
