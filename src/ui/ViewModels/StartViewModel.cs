using System.Collections.ObjectModel;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Models;

    public class StartViewModel : TabViewModel
    {
        public StartViewModel() : base()
        {

            Name = "Start";
            Title = StartTabOptions.Instance.StartTabTitleText;
            IsVisible = true;
            Columns = new ObservableCollection<ColumnViewModel>
            {
                ViewModelLocator.RecentItemsViewModel,
                ViewModelLocator.StartActionsViewModel,
                ViewModelLocator.NewsItemsViewModel,
            };
        }

        public ObservableCollection<ColumnViewModel> Columns { get; set; }

        public bool ShowStartTabTitle
            => StartTabOptions.Instance.ShowStartTabTitle;
    }
}