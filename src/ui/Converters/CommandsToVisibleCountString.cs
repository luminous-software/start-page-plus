using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace StartPagePlus.UI.Converters
{
    using ViewModels;

    [ValueConversion(typeof(ObservableCollection<CommandViewModel>), typeof(string))]
    public class CommandsToVisibleCountString : ConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ObservableCollection<CommandViewModel> commands))
                return Binding.DoNothing;

            var visibleCount = commands.Where(c => c.IsVisible).Count();

            return visibleCount.ToString();
        }
    }
}