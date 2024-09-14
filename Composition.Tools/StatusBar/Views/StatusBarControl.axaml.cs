using Avalonia.Controls;
using Avalonia.Interactivity;
using Composition.Tools.StatusBar.ViewModel;

namespace Composition.Tools.StatusBar.Views;

partial class StatusBarControl : UserControl
{
    private readonly StatusBarViewModel viewModel;

    public StatusBarControl(ViewModel.StatusBarViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        this.DataContext = viewModel;
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        DataContext = null;
    }
}
