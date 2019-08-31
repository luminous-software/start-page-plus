using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class NewsItemsView : UserControl
    {
        public NewsItemsView()
        {
            InitializeComponent();

            var viewModel = ViewModelLocator.NewsItemsViewModel;

            DataContext = viewModel;
            viewModel.ExecuteRefresh();

            NewsItemsListView.SelectionChanged += (sender, e) =>
            {
                var listView = (ListView)sender;

                listView.SelectedItem = null;
            };
        }
    }
}