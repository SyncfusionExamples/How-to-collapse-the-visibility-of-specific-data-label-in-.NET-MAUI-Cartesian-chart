using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollapseDataLabelVisibility
{
    public class ViewModel
    {
        public ObservableCollection<ChartDataModel> ElectricityProductionData { get; set; }

        public List<Brush> CustomBrushes { get; set; }

        public ViewModel()
        {
            CustomBrushes = new List<Brush>();
            CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(38, 198, 218)));
            CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(0, 188, 212)));
            CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(0, 172, 193)));
            CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(0, 151, 167)));
            CustomBrushes.Add(new SolidColorBrush(Color.FromRgb(0, 131, 143)));

            ElectricityProductionData = new ObservableCollection<ChartDataModel>()
            {
               new ChartDataModel("2004",76),
               new ChartDataModel("2005",45),
               new ChartDataModel("2006",55),
               new ChartDataModel("2007",30),
               new ChartDataModel("2008",60),
               new ChartDataModel("2009",40),
               new ChartDataModel("2010",70),
               new ChartDataModel("2011",80),
            };
        }
    }
}
