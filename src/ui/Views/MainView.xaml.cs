using System;
using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = ViewModelLocator.MainViewModel;

        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);
    }
}