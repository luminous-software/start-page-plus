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

            viewModel.ExecuteRefresh();
            DataContext = viewModel;

            //https://www.wpf-tutorial.com/listview-control/listview-grouping/

            //var view = (CollectionView)CollectionViewSource.GetDefaultView(RecentItems.ItemsSource); - returns null!!!
            //var groupDescription = new PropertyGroupDescription("Pinned");

            //view.GroupDescriptions.Add(groupDescription);
        }
    }
}