using Avalonia.Controls;
using Composition.ClientBase;
using Composition.ClientBase.MVVM;
using Composition.Tools.SettingsDisplay.Base;

namespace Composition.Tools.SettingsDisplay;

class ShowSettingsPageController
{
    private readonly IComposition composition;
    private readonly ISettingsUIProvider[] settingsUIProviders;

    public RelayCommand ShowDialogCommand { get; }

    public ShowSettingsPageController(
        IComposition composition,
        ISettingsUIProvider[] settingsUIProviders
    )
    {
        this.composition = composition;
        this.settingsUIProviders = settingsUIProviders;
        ShowDialogCommand = new RelayCommand(() => ShowSettingsWindow());
    }

    void ShowSettingsWindow()
    {
        var verticalScrollPanel = new ScrollViewer()
        {
            HorizontalScrollBarVisibility = Avalonia
                .Controls
                .Primitives
                .ScrollBarVisibility
                .Disabled,
            VerticalScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility.Auto,
        };

        var tabControl = new TabControl();
        verticalScrollPanel.Content = tabControl;

        var tabItems = new Dictionary<string, StackPanel>();
        var groupExpanders = new Dictionary<(string, string), StackPanel>();

        foreach (
            var installation in this
                .settingsUIProviders.SelectMany(w => w.GetSettingsItems())
                .OrderBy(w => w.Order)
        )
        {
            if (!tabItems.TryGetValue(installation.TabName, out var tabStackPanel))
            {
                tabItems[installation.TabName] = tabStackPanel = new StackPanel()
                {
                    Orientation = Avalonia.Layout.Orientation.Vertical,
                };

                tabControl.Items.Add(
                    new TabItem() { Header = installation.TabName, Content = tabStackPanel }
                );
            }

            if (
                !groupExpanders.TryGetValue(
                    (installation.TabName, installation.GroupName),
                    out var groupStackPanel
                )
            )
            {
                groupExpanders[(installation.TabName, installation.GroupName)] = groupStackPanel =
                    new StackPanel()
                    {
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
                    };

                if (string.IsNullOrEmpty(installation.GroupName))
                    groupStackPanel = tabStackPanel;
                else
                {
                    var expander = new Expander()
                    {
                        Header = installation.GroupName,
                        Content = groupStackPanel,
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
                        IsExpanded = true,
                        Padding = new Avalonia.Thickness(0),
                    };

                    tabStackPanel.Children.Add(expander);
                }
            }

            installation.Control.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            groupStackPanel.Children.Add(installation.Control);
        }

        composition.ShowDialogWindow(
            verticalScrollPanel,
            new DialogWindowSettings
            {
                Width = 640,
                Height = 480,
                Title = "Preferences",
            }
        );
    }
}
