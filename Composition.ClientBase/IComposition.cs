using System;

namespace Composition.ClientBase;

public struct DialogWindowSettings
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Title { get; set; }
}

public interface IComposition
{
    IDisposable SetupView(Avalonia.Controls.Control mainViewControl);
    Task ShowDialogWindow(Avalonia.Controls.Control control, DialogWindowSettings settings);
}
