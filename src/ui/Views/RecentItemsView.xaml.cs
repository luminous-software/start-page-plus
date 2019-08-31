using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class RecentItemsView : UserControl
    {
        public RecentItemsView()
        {
            InitializeComponent();

            var viewModel = ViewModelLocator.RecentItemsViewModel;

            DataContext = viewModel;
            viewModel.ExecuteRefresh();

            RecentItemsListView.SelectionChanged += (sender, e) =>
            {
                var listView = (ListView)sender;

                listView.SelectedItem = null;
            };
        }


    }
}