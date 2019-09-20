using System;

namespace StartPagePlus.UI.Interfaces
{
    using Observables;

    public interface IRecentItemCommandService
    {
        ObservableCommandList GetCommands(/*Action showFilter, Action removeFilter, */Action refresh);
    }
}