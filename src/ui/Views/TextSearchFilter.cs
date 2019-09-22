using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace StartPagePlus.UI.Views
{
    using ViewModels;

    internal class TextSearchFilter
    {
        private readonly ICollectionView filteredView;
        private readonly TextBox textBox;

        public TextSearchFilter(ICollectionView filteredView, TextBox textBox)
        {
            this.filteredView = filteredView;
            this.textBox = textBox;

            var filterText = "";

            filteredView.Filter = delegate (object obj)
            {
                if (string.IsNullOrEmpty(filterText))
                    return true;

                var item = obj as RecentItemViewModel;
                var str = item?.Name;

                if (string.IsNullOrEmpty(str))
                    return false;

                var index = str.IndexOf(filterText, 0, StringComparison.InvariantCultureIgnoreCase);

                return (index > -1);
            };

            textBox.TextChanged += delegate
            {
                filterText = textBox.Text;
                filteredView.Refresh();
            };
        }
    }
}