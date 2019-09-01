namespace StartPagePlus.UI.Interfaces
{
    using ViewModels;

    public interface IRecentItemActionService
    {
        void DoAction(RecentItemViewModel currentViewModel);
    }
}