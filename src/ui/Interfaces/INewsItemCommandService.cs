using System;

namespace StartPagePlus.UI.Interfaces
{
    using Observables;

    public interface INewsItemCommandService
    {
        ObservableCommandList GetCommands(Action refresh, Action openSettings);

    }
}