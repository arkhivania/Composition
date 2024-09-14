using System;
using System.Collections.ObjectModel;
using Composition.ClientBase.MVVM;
using Composition.Tools.StatusBar.Base;

namespace Composition.Tools.StatusBar.ViewModel;

class StatusBarViewModel : IStatusBar
{
    class Section : IStatusBarSection
    {
        private readonly StatusBarViewModel viewModel;

        public StateValue<string> StatusText { get; } = new StateValue<string>();

        public Section(StatusBarViewModel viewModel)
        {
            this.viewModel = viewModel;
            viewModel.Sections.Add(this);
        }

        public void Dispose()
        {
            viewModel.Sections.Remove(this);
        }
    }

    public ObservableCollection<Base.IStatusBarSection> Sections { get; } =
        new ObservableCollection<IStatusBarSection>();

    public IStatusBarSection CreateSection()
    {
        var section = new Section(this);
        return section;
    }
}
