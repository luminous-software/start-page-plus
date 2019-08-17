using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();

            DataContext = ViewModelLocator.StartViewModel;
        }
    }
}