using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialAssistent.Services
{
    public interface IUserProfileView
    {
        void UpdateChart(List<DataPoint> dataPoints);
        void ShowMessage(string message);
    }

}
