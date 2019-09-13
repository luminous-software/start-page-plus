namespace StartPagePlus.UI.Interfaces
{
    using ViewModels;

    public interface IRecentItemActionService
    {
        void ExecuteAction(RecentItemViewModel currentViewModel);
    }
}