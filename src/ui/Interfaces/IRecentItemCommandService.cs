using System;

namespace StartPagePlus.UI.Interfaces
{
    using Observables;

    public interface IRecentItemCommandService
    {
        ObservableCommandList GetCommands(Action refresh);

        ObservableContextCommandList GetContextCommands(
            bool canRemove, Action remove,
            bool canPin, Action pin,
            bool canUnpin, Action unpin,
            bool canCopyPath, Action copyPath);
    }
}