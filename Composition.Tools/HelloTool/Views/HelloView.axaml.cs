using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Composition.Tools.HelloTool.ViewModel;

namespace Composition.Tools.HelloTool.Views;

partial class HelloView : UserControl
{
    private readonly HelloViewModel viewModel;

    public HelloView(ViewModel.HelloViewModel viewModel)
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
        this.DataContext = null;
    }
}
