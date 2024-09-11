using System;
using Avalonia.Controls;
using Composition.ClientBase;

namespace Composition.App;

public partial class MainWindow : Window, IComposition
{
    public MainWindow()
    {
        InitializeComponent();
    }

    IDisposable? installedView;

    public IDisposable SetupView(Control mainViewControl)
    {
        installedView?.Dispose();
        this.Content = mainViewControl;
        return installedView = new DisposeAction(() => this.Content = null);
    }
}
