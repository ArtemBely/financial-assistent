using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialAssistent.Services
{
    public interface IUserProfileView
    {
        void UpdateChart(List<DataPoint> dataPoints);
        void ShowMessage(string message);
    }

}
