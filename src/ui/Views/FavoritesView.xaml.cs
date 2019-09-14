using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class FavoritesView : UserControl
    {
        public FavoritesView()
        {
            InitializeComponent();

            DataContext = ViewModelLocator.FavoritesViewModel;
        }
    }
}