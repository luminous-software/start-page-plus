using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class CreateView : UserControl
    {
        public CreateView()
        {
            InitializeComponent();

            DataContext = ViewModelLocator.CreateViewModel;
        }
    }
}