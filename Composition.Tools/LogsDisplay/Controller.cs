using System;
using System.Collections.ObjectModel;
using Composition.ClientBase;
using Composition.ClientBase.MVVM;
using Composition.Tools.Logs.Base;

namespace Composition.Tools.LogsDisplay;

class Controller : Logs.Base.ILogInterceptor
{
    readonly SynchronizationContext synchronizationContext;
    private readonly IComposition composition;

    public RelayCommand ShowLogsCommand { get; }

    public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();

    public Controller(IComposition composition)
    {
        this.composition = composition;

        synchronizationContext = System.Threading.SynchronizationContext.Current;
        if (synchronizationContext == null)
            throw new InvalidOperationException("SynchronizationContext is not initialized");

        ShowLogsCommand = new RelayCommand(Show);
    }

    void Show()
    {
        composition.ShowWindow(
            new Views.LogsDisplayUserControl(this),
            new WindowSettings
            {
                Height = 480,
                Width = 640,
                Title = "Logs",
            }
        );
    }

    public void LogMessageIntercept(DateTime timestamp, Severity severity, string message)
    {
        synchronizationContext.Post(
            p =>
            {
                Messages.Add($"{timestamp} {severity}: {message}");
            },
            null
        );
    }
}
