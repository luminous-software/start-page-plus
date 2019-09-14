using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class NewsItemsView : UserControl
    {
        public NewsItemsView()
        {
            var viewModel = ViewModelLocator.NewsItemsViewModel;

            viewModel.ExecuteRefresh();

            InitializeComponent();

            DataContext = viewModel;

            NewsItemsListView.SelectionChanged += (sender, e) =>
            {
                var listView = (ListView)sender;

                listView.SelectedItem = null;
            };
        }
    }
}