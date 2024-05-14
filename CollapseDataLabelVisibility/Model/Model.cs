using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollapseDataLabelVisibility
{
    public class ChartDataModel
    {
        public string Year { get; set; }
        public double Value { get; set; }

        public ChartDataModel(string name, double value)
        {
            Year = name;
            Value = value;
        }
    }
}
