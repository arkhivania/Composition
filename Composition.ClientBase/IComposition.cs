using System;
using Avalonia.Controls;

namespace Composition.ClientBase;

public struct WindowSettings
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Title { get; set; }
}

public interface IComposition
{
    IDisposable SetupView(Avalonia.Controls.Control mainViewControl);
    Task ShowDialogWindow(Avalonia.Controls.Control control, WindowSettings settings);
    Window ShowWindow(Avalonia.Controls.Control control, WindowSettings settings);
}
