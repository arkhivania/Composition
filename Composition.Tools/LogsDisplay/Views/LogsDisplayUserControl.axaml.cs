using System.Collections.Specialized;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Composition.Tools.LogsDisplay.Views;

partial class LogsDisplayUserControl : UserControl
{
    private readonly Controller controller;

    public LogsDisplayUserControl(Controller controller)
    {
        this.controller = controller;
        InitializeComponent();
        textBox_Main.Text = string.Join(Environment.NewLine, controller.Messages);
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        controller.Messages.CollectionChanged += MessagesCollectionChangedEventHandler;
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        controller.Messages.CollectionChanged -= MessagesCollectionChangedEventHandler;
        base.OnUnloaded(e);
    }

    void MessagesCollectionChangedEventHandler(object? sender, NotifyCollectionChangedEventArgs e)
    {
        textBox_Main.Text = string.Join(Environment.NewLine, controller.Messages);
    }
}
