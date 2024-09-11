using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Composition.ClientBase;
using Composition.MVVM;
using Composition.Tools.PanelView.Base;

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
