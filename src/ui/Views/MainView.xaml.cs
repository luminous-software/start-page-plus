using System;
using System.Windows.Controls;

using Luminous.Code.VisualStudio.Packages;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    public partial class MainView : UserControl
    {
        public MainView(AsyncPackageBase package)
        {
            InitializeComponent();

            MainViewModel.Package = package;

            DataContext = ViewModelLocator.MainViewModel;
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