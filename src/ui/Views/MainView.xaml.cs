using System;
using System.Windows.Controls;
using Microsoft.Win32;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class MainView : UserControl
    {
        public MainView(RegistryKey registryRoot)
        {
            InitializeComponent();

            var mainViewModel = ViewModelLocator.MainViewModel;

            MainViewModel.RegistryRoot = registryRoot;
            DataContext = mainViewModel;

        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);
    }
}