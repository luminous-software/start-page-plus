using System.Collections.ObjectModel;

namespace StartPagePlus.UI.ViewModels
{
    public class StartViewModel : TabViewModel
    {
        public StartViewModel() : base()
        {

            Name = "Start";
            Title = "Hi User, what would you like to do today?";
            IsVisible = true;
            Columns = new ObservableCollection<ColumnViewModel>
            {
                ViewModelLocator.RecentItemsViewModel,
                new StartActionsViewModel
                {
                    Heading = "Get Started",
                    IsVisible = true
                },
                new NewsItemsViewModel
                {
                    Heading = "Read Developer News",
                    IsVisible = true
                }
            };
        }

        public ObservableCollection<ColumnViewModel> Columns { get; set; }
    }
}