using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class RecentItemsView : UserControl
    {
        public RecentItemsView()
        {
            InitializeComponent();

            var recentItemsViewModel = ViewModelLocator.RecentItemsViewModel;

            recentItemsViewModel.ExecuteRefresh();

            DataContext = recentItemsViewModel;

        }
    }
}