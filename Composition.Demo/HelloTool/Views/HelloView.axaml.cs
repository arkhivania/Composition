using Avalonia.Controls;
using Avalonia.Interactivity;
using Composition.Demo.HelloTool.ViewModel;

namespace Composition.Demo.HelloTool.Views;

partial class HelloView : UserControl
{
    private readonly HelloViewModel viewModel;

    public HelloView(HelloViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        DataContext = viewModel;
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        DataContext = null;
    }
}
