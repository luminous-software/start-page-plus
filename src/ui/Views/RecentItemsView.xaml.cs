using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class RecentItemsView : UserControl
    {
        public RecentItemsView()
        {
            InitializeComponent();

            var viewModel = ViewModelLocator.RecentItemsViewModel;

            viewModel.Refresh();

            DataContext = viewModel;

            //https://joshsmithonwpf.wordpress.com/2007/06/12/searching-for-items-in-a-listbox/

            var view = (ListCollectionView)CollectionViewSource.GetDefaultView(viewModel.Items);

            view.GroupDescriptions.Add(new PropertyGroupDescription("PeriodType"));

            view.SortDescriptions.Add(new SortDescription("PeriodType", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

            var filterText = "";

            view.Filter = (object obj) =>
            {
                if (string.IsNullOrEmpty(filterText))
                    return true;

                var item = obj as RecentItemViewModel;
                var name = item?.Name;

                if (string.IsNullOrEmpty(name))
                    return false;

                var index = name.IndexOf(filterText, 0, StringComparison.InvariantCultureIgnoreCase);

                return (index > -1);
            };

            FilterTextBox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                filterText = FilterTextBox.Text;
                view.Refresh();
            };

            RecentItemsListView.SelectionChanged += (sender, e)
                => RecentItemsListView.SelectedItem = null;
        }
    }
}