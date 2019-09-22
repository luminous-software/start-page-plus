using System.ComponentModel;
using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using System.Windows.Data;
    using ViewModels;

    public partial class RecentItemsView : UserControl
    {
        public RecentItemsView()
        {
            InitializeComponent();

            var viewModel = ViewModelLocator.RecentItemsViewModel;

            viewModel.Refresh();

            DataContext = viewModel;

            var view = CollectionViewSource.GetDefaultView(viewModel.Items);

            view.GroupDescriptions.Add(new PropertyGroupDescription { PropertyName = "PeriodType" });

            view.SortDescriptions.Add(new SortDescription { PropertyName = "PeriodType", Direction = ListSortDirection.Ascending });
            view.SortDescriptions.Add(new SortDescription { PropertyName = "Date", Direction = ListSortDirection.Descending });

            new TextSearchFilter(view, FilterText);

            RecentItemsListView.SelectionChanged += (sender, e) =>
            {
                var listView = (ListView)sender;

                listView.SelectedItem = null;
            };
        }
    }
}