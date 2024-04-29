# How-to-collapse-the-visibility-of-specific-data-label-in-.NET-MAUI-Cartesian-chart
This article in the Syncfusion Knowledge Base explains how to collapse the visibility of specific data label in .NET MAUI Cartesian chart

Collapsing the visibility of specific data labels in [Cartesian charts](https://www.syncfusion.com/maui-controls/maui-cartesian-charts) can be a useful way to improve your visualisation and focus on the most important data points. 
This article will explain the step to hide or collapse specific data labels in a Cartesian chart.

**Step 1:** Define a data label template for the series.

**[XAML]**
```
<DataTemplate x:Key="labelTemplate">
    <HorizontalStackLayout HorizontalOptions="Center">
         <Label Text="{Binding Item.Value}" VerticalOptions="Center"/>
         <Label Text="%" VerticalOptions="Center"/>
         <Image Source="greenarrow.png" HeightRequest="15" WidthRequest="15" />
    </HorizontalStackLayout>
</DataTemplate>
```
**Step 2:** Create a value to visibility converter to control the visibility of the data label based on the Y-value. For example, in the following converter, we have collapsed the visibility of the data label for values less than 50.

**[C#]**
```
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
```
**Step 3:** To control the visibility, bind the converter to the DataTemplate layout IsVisible property

**[XAML]**
```
        <chart:SfCartesianChart.Resources>
            <model:VisibilityConverter x:Key="visibilityConverter"/>
            <DataTemplate x:Key="labelTemplate">
                <VerticalStackLayout IsVisible="{Binding Item.Value, Converter={StaticResource visibilityConverter}}" Spacing="5" WidthRequest="100">
                    <HorizontalStackLayout HorizontalOptions="Center" IsVisible="{Binding Item.Value}">
                        <Label Text="{Binding Item.Value}" VerticalOptions="Center"/>
                        <Label Text="%" VerticalOptions="Center"/>
                        <Image Source="greenarrow.png" HeightRequest="15" WidthRequest="15" />
                    </HorizontalStackLayout>
                </VerticalStackLayout>
            </DataTemplate>

        </chart:SfCartesianChart.Resources>
```
**Step 4:** Set the defined DataTemplate to the [LabelTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_LabelTemplate) property of [ColumnSeries](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ColumnSeries.html).

**[XAML]**
```
<chart:SfCartesianChart x:Name="Chart">
. . .
    <chart:SfCartesianChart.Series>
        <chart:ColumnSeries ItemsSource="{Binding ElectricityProductionData}" 
                            LabelTemplate="{StaticResource labelTemplate}"
                            ShowDataLabels="True"
                            XBindingPath="Year" 
                            YBindingPath="Value">
            <chart:ColumnSeries.DataLabelSettings>
                <chart:CartesianDataLabelSettings LabelPlacement="Outer"/>
            </chart:ColumnSeries.DataLabelSettings>
        </chart:ColumnSeries>
        
    </chart:SfCartesianChart.Series>
</chart:SfCartesianChart>
```
**Output**
 ![collapse_the_visibility_of_specific_data_label.png](https://support.syncfusion.com/kb/agent/attachment/article/15889/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIxODEzIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.K6J1qSq6NfGaIUqf9C-P6RbvLE-nRspU5QqfWg49jSc)
