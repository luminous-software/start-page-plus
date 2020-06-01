using System;

namespace StartPagePlus.UI.Interfaces
{
    using Observables;

    public interface IStartActionCommandService
    {
        ObservableCommandList GetCommands(Action openChangelog, Action openWebsite, Action openSettings);
    }
}