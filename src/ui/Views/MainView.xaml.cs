using System;
using System.Windows.Controls;

using Microsoft.Win32;

namespace StartPagePlus.UI.Views
{
    using Options.Models;

    using ViewModels;

    public partial class MainView : UserControl
    {
        public MainView(RegistryKey registryRoot)
        {
            InitializeComponent();

            MainViewModel.RegistryRoot = registryRoot;

            DataContext = ViewModelLocator.MainViewModel;

            LayoutRoot.MaxWidth = SettingOptions.Instance.MaxWidth;
        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var tabControl = sender as TabControl;
        //    var selectedViewModel = tabControl?.SelectedContent;

        //    if (selectedViewModel is RecentItemsViewModel recentItems)
        //    {
        //        var filterText = recentItems.FindName("FilterText") as TextBox;

        //        Keyboard.Focus(filterText);
        //    }

        //    e.Handled = true;
        //}
    }
}