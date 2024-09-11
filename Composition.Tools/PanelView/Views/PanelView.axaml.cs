using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Composition.Tools.PanelView.Base;

namespace Composition.Tools.PanelView.Views;

partial class PanelView : UserControl
{
    readonly List<IDisposable> disposables = new List<IDisposable>();
    private readonly IToolsPanelArrange[] toolsPanelArrange;
    private readonly IMainViewArrange[] mainViewArrange;

    public PanelView(IToolsPanelArrange[] toolsPanelArrange, IMainViewArrange[] mainViewArrange)
    {
        InitializeComponent();
        this.toolsPanelArrange = toolsPanelArrange;
        this.mainViewArrange = mainViewArrange;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        foreach (var tpa in toolsPanelArrange.OrderBy(w => w.Order))
            disposables.AddRange(tpa.ArrangeToolsPanel(stackPanel_Tools));
        
        foreach (var tpa in mainViewArrange.OrderBy(w => w.Order))
            disposables.AddRange(tpa.ArrangeView(grid_MainView));
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        foreach (var d in disposables)
            d.Dispose();
        disposables.Clear();
    }
}
