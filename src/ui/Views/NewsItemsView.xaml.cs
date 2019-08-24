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

            viewModel.ExecuteRefresh();

            DataContext = viewModel;

        }
    }
}