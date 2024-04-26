using System.Globalization;

namespace CollapseDataLabelVisibility
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

    }


    public class VisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (!(value is double))
                return null;

            var labelValue = (double)value;
            if (labelValue < 50)
                return false;
            return true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }

}
