using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using StartPagePlus.UI.ViewModels;

    public partial class StartActionsView : UserControl
    {
        public StartActionsView()
        {
            InitializeComponent();

            var viewModel = ViewModelLocator.StartActionsViewModel;

            DataContext = viewModel;

            StartActionsListView.SelectionChanged += (sender, e) =>
            {
                var listView = (ListView)sender;

                listView.SelectedItem = null;
            };
        }
    }
}