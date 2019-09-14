using System.Windows.Controls;
using StartPagePlus.UI.ViewModels;

namespace StartPagePlus.UI.Views
{
    public partial class NewsView : UserControl
    {
        public NewsView()
        {
            InitializeComponent();

            DataContext = ViewModelLocator.NewsViewModel;
        }
    }
}