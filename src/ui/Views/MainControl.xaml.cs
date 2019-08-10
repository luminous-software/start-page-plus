using System;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;

            var mainControlViewModel = ViewModelLocator.MainControlViewModel;
            DataContext = mainControlViewModel;

        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);
    }
}