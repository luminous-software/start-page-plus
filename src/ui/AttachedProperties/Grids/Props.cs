using System.Windows;
using System.Windows.Controls;

namespace StartPagePlus.UI.AttachedProperties.Grids
{
    public class Props : DependencyObject
    {
        // using a DependencyProperty as the backing store enables animation, styling, binding, etc...

        public static readonly DependencyProperty RowHeightsProperty =
            DependencyProperty.RegisterAttached("RowHeights", typeof(string), typeof(Props),
            new PropertyMetadata("", RowHeightsChanged));

        public static readonly DependencyProperty ColumnWidthsProperty =
            DependencyProperty.RegisterAttached("ColumnWidths", typeof(string), typeof(Props),
            new PropertyMetadata("", ColumnWidthsChanged));

        public static string GetRowHeights(DependencyObject obj)
            => (string)obj.GetValue(RowHeightsProperty);

        public static void SetRowHeights(DependencyObject obj, string value)
            => obj.SetValue(RowHeightsProperty, value);

        private static void RowHeightsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (!(d is Grid grid))
            {
                return;
            }

            grid.RowDefinitions.Clear();

            var definitions = args.NewValue.ToString();

            if (string.IsNullOrEmpty(definitions))
            {
                return;
            }

            var heights = definitions.Split(',');

            foreach (var height in heights)
            {
                if (height == "Auto")
                {
                    grid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = GridLength.Auto
                    });
                }
                else if (height.EndsWith("*"))
                {
                    var height2 = height.Replace("*", "");

                    if (string.IsNullOrEmpty(height2))
                    {
                        height2 = "1";
                    }

                    var numHeight = int.Parse(height2);

                    grid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = new GridLength(numHeight, GridUnitType.Star)
                    });
                }
                else
                {
                    var numHeight = int.Parse(height);

                    grid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = new GridLength(numHeight, GridUnitType.Pixel)
                    });
                }
            }
        }

        public static string GetColumnWidths(DependencyObject obj)
            => (string)obj.GetValue(ColumnWidthsProperty);

        public static void SetColumnWidths(DependencyObject obj, string value)
            => obj.SetValue(ColumnWidthsProperty, value);

        private static void ColumnWidthsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (!(d is Grid grid))
            {
                return;
            }

            grid.ColumnDefinitions.Clear();

            var definitions = args.NewValue.ToString();

            if (string.IsNullOrEmpty(definitions))
            {
                return;
            }

            var widths = definitions.Split(',');

            foreach (var width in widths)
            {
                if (width == "Auto")
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = GridLength.Auto
                    });
                }
                else if (width.EndsWith("*"))
                {
                    var width2 = width.Replace("*", "");

                    if (string.IsNullOrEmpty(width2))
                    {
                        width2 = "1";
                    }

                    var numWidth = int.Parse(width2);

                    grid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(numWidth, GridUnitType.Star)
                    });
                }
                else
                {
                    var numWidth = int.Parse(width);

                    grid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(numWidth, GridUnitType.Pixel)
                    });
                }
            }
        }
    }
}