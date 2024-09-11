using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Composition.ClientBase;

namespace Composition.App;

public partial class MainWindow : Window
{
    readonly List<IDisposable> disposables = new List<IDisposable>();
    private readonly IToolsPanelArrange[] toolsPanelArrange;
    private readonly IMainViewArrange[] mainViewArrange;

    public MainWindow(IToolsPanelArrange[] toolsPanelArrange, IMainViewArrange[] mainViewArrange)
    {
        InitializeComponent();
        this.toolsPanelArrange = toolsPanelArrange;
        this.mainViewArrange = mainViewArrange;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        foreach (var tpa in toolsPanelArrange.OrderBy(w => w.Order))
            disposables.AddRange(tpa.ArrangeToolsPanel(stackPanel_Tools));
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        foreach (var d in disposables)
            d.Dispose();
        disposables.Clear();
    }
}
