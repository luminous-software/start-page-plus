using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    public partial class StartActionsView : UserControl
    {
        public StartActionsView()
        {
            InitializeComponent();

            StartActionsListView.SelectionChanged += (sender, e) =>
            {
                var listView = (ListView)sender;

                listView.SelectedItem = null;
            };
        }
    }
}